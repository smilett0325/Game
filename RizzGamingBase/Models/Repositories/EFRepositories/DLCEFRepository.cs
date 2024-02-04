using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Repositories.EFRepositories
{
	public class DLCEFRepository : IDLCRepository
	{
		AppDbContext db = new AppDbContext();

		public void Create(DLCEntity entity)
		{
			DLC model = new DLC()
			{
				Id = entity.Id,
				GameId = entity.GameId,
				AttachedGameId = entity.AttachedGameId
			};

			db.DLCs.Add(model);
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			DLC model = db.DLCs.Find(id);
			db.DLCs.Remove(model);
			db.SaveChanges();
		}

		public DLCEntity Search(int id)
		{
			return db.DLCs.AsNoTracking()
				.Where(d => d.Id == id)
				.Select(v => new DLCEntity
				{
					Id = v.Id,
					GameId = v.GameId,
					AttachedGameId = v.AttachedGameId
				})
				.FirstOrDefault();
		}

		public void Update(DLCEntity entity)
		{
			DLC model = db.DLCs.Find(entity.Id);

			model.GameId = entity.GameId;
			model.AttachedGameId = entity.AttachedGameId;

			db.SaveChanges();
		}

		public List<GameEntity> GetDLCGame(int id)
		{
			return db.DLCs.AsNoTracking()
				.Where(x => x.AttachedGameId == id)
				.Join(
				db.Games,
				x => x.GameId,
				y => y.Id,
				(x, y) => y
				)
				.Select(v => new GameEntity
				{
					Id = v.Id,
					Name = v.Name,
					Introduction = v.Introduction,
					Description = v.Description,
					ReleaseDate = v.ReleaseDate,
					Price = v.Price,
					Cover = v.Cover,
					DeveloperId = v.DeveloperId,
					MaxPercent = v.MaxPercent,
				})
				.ToList();
		}
	}
}
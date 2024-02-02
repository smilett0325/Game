using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Repositories.EFRepositories
{
	public class GameEFRepository : IGameRepository
	{
		AppDbContext db = new AppDbContext();

		public List<GameEntity> Filter(Func<Game, bool> condition = null)
		{
			//包裝轉型為擴充方法，可能影響到效能
			return db.Games.AsNoTracking()
				.Where(condition ?? (x => true))
				.AsEnumerable()
				.Select(g => g.EFToEntity())
				.ToList();
		}

		public GameEntity Search(int id)
		{
			return db.Games.AsNoTracking()
				.Where(d => d.Id == id)
				.AsEnumerable()
				.Select(d => d.EFToEntity())
				.FirstOrDefault();
		}

		public int Create(GameEntity entity)
		{
			Game model = entity.EntityToEF();
			db.Games.Add(model);
			db.SaveChanges();

			db.Entry(model).Reload(); 
			return model.Id;
		}

		public void Delete(int id)
		{
			Game model = db.Games.Find(id);
			db.Games.Remove(model);
			db.SaveChanges();
		}

		public void Update(GameEntity entity)
		{
			Game model = db.Games.Find(entity.Id);

			model.Name = entity.Name;
			model.Price = entity.Price;
			model.Cover = entity.Cover;
			model.ReleaseDate = entity.ReleaseDate;
			model.Introduction = entity.Introduction;
			model.MaxPercent = entity.MaxPercent;
			model.Description = entity.Description;
			model.Video = entity.Video;

			db.SaveChanges();
		}
	}
}
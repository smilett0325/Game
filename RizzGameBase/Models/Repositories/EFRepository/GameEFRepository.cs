using RizzGameBase.Models.EFModels;
using RizzGameBase.Models.Entities;
using RizzGameBase.Models.Exts;
using RizzGameBase.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGameBase.Models.Repositories.EFRepository
{
	public class GameEFRepository : IGameRepository
	{
		AppDbContext db = new AppDbContext();

		public List<GameEntity> Filter(Func<Game, bool> condition = null)
		{
			return db.Games.AsNoTracking()
				.Where(condition ?? (x => true))
				.Select(g => g.EFToEntity())
				.ToList();
		}	
		
		public GameEntity Search(int id)
		{
			return db.Games.AsNoTracking()
				.Where(d => d.Id == id)
				.Select(d => d.EFToEntity())
				.Single();
		}

		public void Create(GameEntity entity)
		{
			Game model = entity.EntityToEF();
			db.Games.Add(model);
			db.SaveChanges();
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

			entity.Name = model.Name;
			entity.Price = model.Price;
			entity.Image = model.Image;
			entity.DeveloperId = model.DeveloperId;
			entity.DiscountId = model.DiscountId;
			entity.ReleaseDate = model.ReleaseDate;
			entity.Introduction = model.Introduction;
			entity.GameTagId = model.GameTagId;
			entity.MaxPersent = model.MaxPersent;
			entity.Description = model.Description;

			db.SaveChanges();
		}
	}
}
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
	public class GameEFRepository
	{

		AppDbContext db;

		public List<GameEntity> FilterGames(Func<EFModels.Game, bool> filterCondition = null)
		{
			return db.Games.AsNoTracking()
				.Where(filterCondition ?? (x => true))
				.Select(d => d.EFToEntity())
				.ToList();
		}

		public List<GameEntity> ByDeveloper(int developerId)
		{
			return FilterGames(game => game.DeveloperId == developerId);
		}


		public List<GameEntity> ByDiscount(int discountId)
		{
			return FilterGames(game => game.DiscountId == discountId);
		}


		public List<GameEntity> ByTag(int tagId)
		{
			return FilterGames(game => game.GameTagId == tagId);
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
			var model = new EFModels.Game
			{
				Name = entity.Name,
				Price = entity.Price,
				Image = entity.Image,
				DeveloperId = entity.DeveloperId,
				DiscountId = entity.DiscountId,
				ReleaseDate = entity.ReleaseDate,
				Introduction = entity.Introduction,
				GameTagId = entity.GameTagId,
				MaxPersent = entity.MaxPersent,
				Description = entity.Description,
			};
			db.Games.Add(model);
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			var model = db.Games.Find(id);
			db.Games.Remove(model);
			db.SaveChanges();
		}

		public void Update(GameEntity entity)
		{
			var model = db.Games.Find(entity.Id);

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
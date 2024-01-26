using RizzGameBase.Models.Dtos;
using RizzGameBase.Models.EFModels;
using RizzGameBase.Models.Entities;
using RizzGameBase.Models.Exts;
using RizzGameBase.Models.IRepositories;
using RizzGameBase.Models.IServices;
using RizzGameBase.Models.Repositories.EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RizzGameBase.Models.ViewModels; // Include

namespace RizzGameBase.Models.Services
{
	public class GameService : IGameService
	{
		private IGameRepository _repo;

		public GameService(IGameRepository repo)
		{
			_repo = repo;
		}

		public GameDto Search(int id)
		{
			return _repo.Search(id).EntityToDto();
		}

		public List<GameDto> Filter(Func<Game, bool> condition = null)
		{
			return _repo.Filter().EntityToDto();
			//         var data = _repo.Filter();

			//         var result = new List<GameDto>();

			//         foreach (var item in data)
			//{
			//	result.Add(item.EntityToDto());
			//         }

			//         return result;
		}

		public List<GameDto> FilterByDeveloper(int developerId)
		{
			var data = _repo.Filter(g => g.DeveloperId == developerId);

            var result = new List<GameDto>();

            foreach (var item in data)
            {
                result.Add(item.EntityToDto());
            }

            return result;
        }

		public List<GameDto> FilterByDiscount(int discountId)
		{
			var db = new AppDbContext();

			return db.DiscountItems.AsNoTracking()
				.Where(g => g.DiscountId == discountId)
				.Include(g => g.Game)
				.Select(g => new GameDto
				{
					Id = g.GameId,
					Name = g.Game.Name,
					Introduction = g.Game.Introduction,
					Description = g.Game.Description,
					ReleaseDate = g.Game.ReleaseDate,
					Price = g.Game.Price,
					Image = g.Game.Image,
					DeveloperId = g.Game.DeveloperId,
					MaxPercent = g.Game.MaxPercent,
				})
				.ToList();
		}

		public List<GameDto> FilterByTag(int tagId)
		{
			//tagid => gt gameid => game
			var db = new AppDbContext();
			
			return db.GameTags.AsNoTracking()
				.Where(g => g.TagId == tagId)
				.Include(g => g.Game)
				.Select(g => new GameDto
				{
					Id = g.GameId,
					Name = g.Game.Name,
					Introduction = g.Game.Introduction,
					Description = g.Game.Description,
					ReleaseDate = g.Game.ReleaseDate,
					Price = g.Game.Price,
					Image = g.Game.Image,
					DeveloperId = g.Game.DeveloperId,
					MaxPercent = g.Game.MaxPercent,
				})
				.ToList();
		}
	}
}
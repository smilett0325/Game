using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.Interfaces;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Services
{
	public class GameService
	{
		private IGameRepository _repo;

		public GameService(IGameRepository repo)
		{
			_repo = repo;
		}
		public void DGSave(DeveloperGameEditVm vm)
		{
			var game = new GameDto();
			var video = new List<VideoDto>();
			var image = new List<ImageDto>();
			var gt = new List<TagDto>();
			var dlc = new List<GameDto>();
			//var discount = new List<DiscountDto>();

			//todo 實作儲存
			//update gmae

			game.Name = vm.Name;
			game.Introduction = vm.Introduction;
			game.Description = vm.Description;
			game.ReleaseDate = vm.ReleaseDate;
			game.Price = vm.Price;
			game.Image = vm.Image;
			game.MaxPercent = vm.MaxPercent;

			//Create video

			//Create image

			//Update or Create gt

			//Update or Create dlc

			//Update or Create discount
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
using RizzGameBase.Models.Dtos;
using RizzGameBase.Models.EFModels;
using RizzGameBase.Models.Entities;
using RizzGameBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;

namespace RizzGameBase.Models.Exts
{
	public static class GameExts
	{
		public static GameEntity EFToEntity(this Game model)
		{
			return new GameEntity
			{
				Id = model.Id,
				Name = model.Name,
				Introduction = model.Introduction,
				Description = model.Description,
				ReleaseDate = model.ReleaseDate,
				Price = model.Price,
				Image = model.Image,
				DeveloperId = model.DeveloperId,
				MaxPercent = model.MaxPercent,
			};
		}

		public static Game EntityToEF(this GameEntity model)
		{
			return new Game
			{
				Id = model.Id,
				Name = model.Name,
				Introduction = model.Introduction,
				Description = model.Description,
				ReleaseDate = model.ReleaseDate,
				Price = model.Price,
				Image = model.Image,
				DeveloperId = model.DeveloperId,
				MaxPercent = model.MaxPercent,
			};
		}

		public static GameDto EntityToDto(this GameEntity model)
		{
			return new GameDto
			{
				Id = model.Id,
				Name = model.Name,
				Introduction = model.Introduction,
				Description = model.Description,
				ReleaseDate = model.ReleaseDate,
				Price = model.Price,
				Image = model.Image,
				DeveloperId = model.DeveloperId,
				MaxPercent = model.MaxPercent,
			};
		}

		public static List<GameDto> EntityToDto(this List<GameEntity> model)
		{
			return model.Select(x => x.EntityToDto()).ToList();
			//return new GameDto
			//{
			//    Id = model.Id,
			//    Name = model.Name,
			//    Introduction = model.Introduction,
			//    Description = model.Description,
			//    ReleaseDate = model.ReleaseDate,
			//    Price = model.Price,
			//    Image = model.Image,
			//    DeveloperId = model.DeveloperId,
			//    GameTagId = model.GameTagId,
			//    DiscountId = model.DiscountId,
			//    MaxPercent = model.MaxPercent,
			//};
		}

		public static GameEntity DtoToEntity(this GameDto model)
		{
			return new GameEntity
			{
				Id = model.Id,
				Name = model.Name,
				Introduction = model.Introduction,
				Description = model.Description,
				ReleaseDate = model.ReleaseDate,
				Price = model.Price,
				Image = model.Image,
				DeveloperId = model.DeveloperId,
				MaxPercent = model.MaxPercent,
			};
		}

		public static GameIndexVm ToGameVm(this GameDto model)
		{
			return new GameIndexVm
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				Image = model.Image,
			};
		}

		public static List<GameIndexVm> ToGameVm(this List<GameDto> model)
		{
			return model.Select(x => x.ToGameVm()).ToList();
		}

		public static DeveloperGameEditVm ToDGVm(this GameDto model)
		{
			var db = new AppDbContext();

			var gts = db.GameTags.AsNoTracking()
				.Where(x => x.Id == model.Id)
				.Include(gt => gt.Tag)
				.ToList();

			List<Tag> tags = gts.Select(gt => gt.Tag).ToList();

			var di = db.DiscountItems.AsNoTracking()
				.Where(x => x.GameId == model.Id)
				.Include(x => x.Discount)
				.ToList();

			List<Discount> discounts = di.Select(x => x.Discount).ToList();

			var dlc = db.DLCs.AsNoTracking()
					.Where(x => x.AttachmentGameId == model.Id)
					.ToList();

			var vm = db.Games.AsNoTracking()
				.Include(x => x.Videos)
				.Include(x => x.Images)
				.Include(x => x.DLCs)
				.Where(x => x.Id == model.Id)
				.Select(x => new DeveloperGameEditVm
				{
					Id = x.Id,
					Name = x.Name,
					Introduction = x.Introduction,
					Description = x.Description,
					ReleaseDate = x.ReleaseDate,
					Price = x.Price,
					Image = x.Image,
					DisplayImages = x.Images.ToList(),
					DisplayVideos = x.Videos.ToList(),
					Tags = tags,
					MaxPercent = x.MaxPercent,
					Discounts = discounts,
					DLCs = dlc,
				})
				.FirstOrDefault();

			return vm;
		}

		public static List<DeveloperGameEditVm> ToDGVm(this List<GameDto> model)
		{
			return model.Select(x => x.ToDGVm()).ToList();
		}
	}
}
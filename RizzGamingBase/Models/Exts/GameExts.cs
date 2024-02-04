using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Repositories.EFRepositories;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Exts
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
				Cover = model.Cover,
				DeveloperId = model.DeveloperId,
				MaxPercent = model.MaxPercent,
				Video = model.Video,
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
				Cover = model.Cover,
				DeveloperId = model.DeveloperId,
				MaxPercent = model.MaxPercent,
				Video = model.Video,
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
				Cover = model.Cover,
				DeveloperId = model.DeveloperId,
				MaxPercent = model.MaxPercent,
				Video = model.Video,
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
			//    Cover = model.Cover,
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
				Cover = model.Cover,
				DeveloperId = model.DeveloperId,
				MaxPercent = model.MaxPercent,
				Video = model.Video,
			};
		}

		public static GameIndexVm ToGameVm(this GameDto model)
		{
			return new GameIndexVm
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				Cover = model.Cover,
			};
		}

		public static List<GameIndexVm> ToGameVm(this List<GameDto> model)
		{
			return model.Select(x => x.ToGameVm()).ToList();
		}

		public static DeveloperGameEditVm ToDGVm(this GameDto model)
		{
			var db = new AppDbContext();

			var iR = new ImageEFRepository();
			var dlcR = new DLCEFRepository();
			var tR = new TagEFRepository();
			//var dR = new DiscountEFRepository();
			var gR = new GameEFRepository();

			var displayImage = iR.GetAll(model.Id);

			var tag = tR.GetAll(model.Id);
			var dlc = gR.GetDLCGame(model.Id);
			//var discount =

			var imageList = new List<string>();
			foreach (var item in displayImage)
			{
				imageList.Add(item.DisplayImage);
			};

			var tagList = new List<TagDto>();
			foreach (var item in tag)
			{
				tagList.Add(item.EntityToDto());
			};

			var dlcList = new List<GameDto>();
			foreach (var item in dlc)
			{
				dlcList.Add(item.EntityToDto());
			};

			var vm = new DeveloperGameEditVm
			{
				Id = model.Id,
				DeveloperId = model.DeveloperId,
				Name = model.Name,
				Price = model.Price,
				Cover = model.Cover,
				Introduction = model.Introduction,
				Description = model.Description,
				ReleaseDate = model.ReleaseDate,
				//DeveloperId = model.DeveloperId, //是否需要?
				MaxPercent = model.MaxPercent,
				DisplayImages = imageList,
				Video = model.Video,
				Tags = tagList,
				DLCs = dlcList,
			};

			return vm;
		}

	}
}
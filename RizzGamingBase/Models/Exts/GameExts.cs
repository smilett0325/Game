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

			var iR = new ImageEFRepository();
			var vR = new VideoEFRepository();
			var dlcR = new DLCEFRepository();
			var tR = new TagEFRepository();
			var dR = new DiscountEFRepository();
			var gR = new GameEFRepository();

			var displayImage = iR.GetAll(model.Id);
			var displayVideo = vR.GetAll(model.Id);
			var tag = tR.GetAll(model.Id);
			var dlc = dlcR.GetGameDLC(model.Id);
			//var discount =

			var imageList = new List<ImageDto>();
			foreach (var item in displayImage)
			{
				imageList.Add(item.EntityToDto());
			};

			var videoList = new List<VideoDto>();
			foreach (var item in displayVideo)
			{
				videoList.Add(item.EntityToDto());
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
				Name = model.Name,
				Price = model.Price,
				Image = model.Image,
				Introduction = model.Introduction,
				Description = model.Description,
				ReleaseDate = model.ReleaseDate,
				//DeveloperId = model.DeveloperId, //是否需要?
				MaxPercent = model.MaxPercent,
				DisplayImages = imageList,
				DisplayVideos = videoList,
				Tags = tagList,
				DLCs = dlcList,
				Discounts = new List<DiscountDto>(),
			};

			//var gts = db.GameTags.AsNoTracking()
			//	.Where(x => x.Id == model.Id)
			//	.Include(gt => gt.Tag)
			//	.ToList();

			//List<Tag> tags = gts.Select(gt => gt.Tag).ToList();

			//var di = db.DiscountItems.AsNoTracking()
			//	.Where(x => x.GameId == model.Id)
			//	.Include(x => x.Discount)
			//	.ToList();

			//List<Discount> discounts = di.Select(x => x.Discount).ToList();

			//var dlc = db.DLCs.AsNoTracking()
			//		.Where(x => x.AttachmentGameId == model.Id)
			//		.Include(x => x.Game)
			//		.ToList();

			//List<Game> dlcGames = dlc.Select(x => x.Game).ToList();



			//複雜像單獨查詢是否會優化效能?

			//var vm = db.Games.AsNoTracking()
			//	.Include(x => x.Videos)
			//	.Include(x => x.Images)
			//	.Include(x => x.DLCs)
			//	.Where(x => x.Id == model.Id)
			//	.Select(x => new DeveloperGameEditVm
			//	{
			//		Id = x.Id,
			//		Name = x.Name,
			//		Introduction = x.Introduction,
			//		Description = x.Description,
			//		ReleaseDate = x.ReleaseDate,
			//		Price = x.Price,
			//		Image = x.Image,
			//		DisplayImages = x.Images.ToList(),  //無法轉型成dto
			//		DisplayVideos = x.Videos.ToList(),
			//		MaxPercent = x.MaxPercent,
			//		Tags = db.GameTags
			//			.Where(gt => gt.GameId == x.Id)
			//			.Join(
			//				db.Tags,
			//				gt => gt.TagId,
			//				t => t.Id,
			//				(gt, t) => t
			//			)
			//			.ToList(),
			//		Discounts = db.DiscountItems
			//			.Where(d => d.GameId == x.Id)
			//			.Join(
			//				db.Discounts,
			//				di => di.DiscountId,
			//				d => d.Id,
			//				(di, d) => d
			//			)
			//			.ToList(),
			//		DLCs = db.DLCs
			//			.Where(dlc => dlc.AttachmentGameId == x.Id)
			//			.Select(dlc => dlc.Game)
			//			.ToList(),
			//	})
			//	.FirstOrDefault();

			return vm;
		}

	}
}
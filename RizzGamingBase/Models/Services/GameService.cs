using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.Infra;
using RizzGamingBase.Models.Interfaces;
using RizzGamingBase.Models.Repositories.EFRepositories;
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
		public void DGSave(DeveloperGameEditVm vm, string displayImagePath, string coverPath, string displayVideoPath)
		{
			var vRepo = new VideoEFRepository();
			var iRepo = new ImageEFRepository();
			var gRepo = new GTEFRepository();
			var dlcRepo = new DLCEFRepository();
			var dicepo = new DiscountEFRepository();


			var game = new GameDto();
			var video = new List<VideoDto>();
			var image = new List<ImageDto>();
			var gt = new List<TagDto>();
			var dlc = new List<GameDto>();
			var discount = new List<DiscountDto>();

			//todo 實作儲存
			//update gmae
			game.Id = vm.Id;
			game.Name = vm.Name;
			game.Introduction = vm.Introduction;
			game.Description = vm.Description;
			game.ReleaseDate = vm.ReleaseDate;
			game.Price = vm.Price;
			game.DeveloperId = vm.DeveloperId;
			game.MaxPercent = vm.MaxPercent;
			//game.Image = vm.Image;

			_repo.Update(game.DtoToEntity());
			//Create video



			//Create image

			//Update or Create gt

			//Update or Create dlc

			//Update or Create discount

			//public ActionResult Create(ProductVm model, HttpPostedFileBase file1)
			//{
			//	//判斷ModelState.IsVaild
			//	if (!ModelState.IsValid) { return View(model); }

			//	string path = Server.MapPath("/UploadFile");

			//	try
			//	{
			//		string newFileName = new UploadFileHelper().UploadImageFile(file1, path);
			//		model.FileName = newFileName;

			//		//todo 新增紀錄

			//		return RedirectToAction("Index");
			//	}
			//	catch (Exception ex)
			//	{
			//		ModelState.AddModelError(string.Empty, ex.Message);
			//	}

			//	return View();
			//}
		}

		public void Create(DeveloperGameEditVm vm, int developerId, string displayImagePath, string coverPath, string displayVideoPath, HttpPostedFileBase cover, IEnumerable<HttpPostedFileBase> displayImage, HttpPostedFileBase displayVideo)
		{
			var vRepo = new VideoEFRepository();
			var iRepo = new ImageEFRepository();
			var gtRepo = new GTEFRepository();
			var dlcRepo = new DLCEFRepository();
			var uploadFileHelper = new UploadFileHelper();
			//var disepo = new DiscountItemEFRepository();

			var game = new GameDto();
			//var videos = new List<VideoDto>();
			//var video = new VideoDto();
			//var images = new List<ImageDto>();
			//var gts = new List<TagDto>();
			//var dlcs = new List<GameDto>();
			//var discount = new List<DiscountDto>();

			//todo 實作儲存
			//update gmae
			//game.Id = vm.Id;
			game.Name = vm.Name;
			game.Introduction = vm.Introduction;
			game.Description = vm.Description;
			game.ReleaseDate = vm.ReleaseDate;
			game.Price = vm.Price;
			game.DeveloperId = vm.DeveloperId;
			game.MaxPercent = vm.MaxPercent;
			game.Image = uploadFileHelper.UploadCoverFile(cover, coverPath,developerId); //todo 


			_repo.Create(game.DtoToEntity());

			//Create video

			foreach (var item in vm.DisplayVideos)
			{
				var video = new VideoEntity
				{
					GameId = game.Id,
					DisplayVideo = item.DisplayVideo,
				};
				
				vRepo.Create(video);
			};

			//Create image

			foreach (var item in vm.DisplayImages)
			{
				var image = new ImageEntity
				{
					GameId = game.Id,
					DisplayImage = item.DisplayImage,
				};

				iRepo.Create(image);
			};

			//Update or Create gt

			foreach (var item in vm.Tags)
			{
				var gt = new GTEntity
				{
					GameId = game.Id,
					TagId = item.Id,
				};
				gtRepo.Create(gt);
			};

			//Update or Create dlc

			foreach (var item in vm.DLCs)
			{
				var dlc = new DLCEntity
				{
					GameId = item.Id,
					AttachmentGameId = game.Id,
				};
				dlcRepo.Create(dlc);
			};

			//Update or Create discount

			//foreach (var item in vm.Discounts)
			//{
			//	var discount = new DiscountItem
			//	{
			//		DiscountId = item.Id,
			//		GameId = game.Id,
			//	};
			//	disRepo.Create(discount);
			//};
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

		public List<TagDto> GetAllTag()
		{
			TagEFRepository tagRepo = new TagEFRepository();
			var tags = tagRepo.GetAll().ToList();
			List<TagDto> result = new List<TagDto>();

			foreach (var item in tags)
			{
				result.Add(item.EntityToDto());
			}

			return result;
		}
	}
}
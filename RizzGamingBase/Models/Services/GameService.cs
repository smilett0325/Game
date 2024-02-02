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
using System.IO;
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
			var iRepo = new ImageEFRepository();
			var gRepo = new GTEFRepository();
			var dlcRepo = new DLCEFRepository();
			//var dicepo = new DiscountEFRepository();

			//cover，image，bug要修
			var game = new GameDto();
			string[] image;
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
			//game.Video = vm.Video;

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

		//public void Create(DeveloperGameEditVm vm, int developerId, string displayImagePath, string coverScratchPath, string displayVideoScratchPath, HttpPostedFileBase cover, IEnumerable<HttpPostedFileBase> displayImages, HttpPostedFileBase displayVideo, string[] selectedTags, string[] attachedGame)
		public void Create(DeveloperGameEditVm vm, int developerId, HttpPostedFileBase cover, IEnumerable<HttpPostedFileBase> displayImages, HttpPostedFileBase displayVideo, string[] selectedTags, string[] attachedGame)
		{
			var iRepo = new ImageEFRepository();
			var gtRepo = new GTEFRepository();
			var dlcRepo = new DLCEFRepository();
			var uploadFileHelper = new UploadFileHelper();
			
			var game = new GameDto
			{
				Name = vm.Name,
				Introduction = vm.Introduction,
				Description = vm.Description,
				ReleaseDate = vm.ReleaseDate,
				Price = vm.Price,
				//DeveloperId = vm.DeveloperId,
				DeveloperId = developerId,
				MaxPercent = vm.MaxPercent,
				Cover = cover.FileName,
				Video = displayVideo.FileName,
			};

			uploadFileHelper.UploadCoverFileToScratch(cover); //todo , coverScratchPath
			uploadFileHelper.UploadDisplayVideoFileToScratch(displayVideo);//, displayVideoScratchPath
			var gameId = _repo.Create(game.DtoToEntity());
			uploadFileHelper.MoveCoverFromScratch(game.Cover, developerId, gameId);
			uploadFileHelper.MoveVideoFromScratch(game.Video, developerId, gameId);

			//Create image

			foreach (var di in displayImages)
			{
				var image = new ImageEntity
				{
					GameId = gameId,
					DisplayImage = di.FileName,
				};

				uploadFileHelper.UploadDisplayImageFile(di, developerId, gameId);//, displayImagePath
				iRepo.Create(image);
			};

			//Update or Create gt

			foreach (var tag in selectedTags)
			{
				var gt = new GTEntity
				{
					GameId = gameId,
					TagId = Convert.ToInt32(tag),
				};
				gtRepo.Create(gt);
			};

			//Update or Create dlc
			if (attachedGame != null)
			{
				foreach (var item in attachedGame)
				{
					if (item != "12")
					{
						var dlc = new DLCEntity
						{
							GameId = Convert.ToInt32(item),
							AttachedGameId = gameId,
						};
						dlcRepo.Create(dlc);
					};
				};
			};
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
					Cover = g.Game.Cover,
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
					Cover = g.Game.Cover,
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
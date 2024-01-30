using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
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
			var game = new GameDto();
			var video = new List<VideoDto>();
			var image = new List<ImageDto>();
			var gt = new List<TagDto>();
			var dlc = new List<GameDto>();
			//var discount = new List<DiscountDto>();

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

		public void Create(DeveloperGameEditVm vm, string displayImagePath, string coverPath, string displayVideoPath, HttpPostedFileBase cover, IEnumerable<HttpPostedFileBase> displayImage, IEnumerable<HttpPostedFileBase> displayVideo)
		{
			var game = new GameDto();
			var video = new List<VideoDto>();
			var image = new List<ImageDto>();
			var gt = new List<TagDto>();
			var dlc = new List<GameDto>();
			//var discount = new List<DiscountDto>();

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
			string coverName = new UploadFileHelper().UploadCoverFile(cover, coverPath, vm.DeveloperId, vm.Id);
			game.Image = coverName;

			//Create video



			//Create image

			//Update or Create gt

			//Update or Create dlc

			//Update or Create discount

			_repo.Create(game.DtoToEntity());
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
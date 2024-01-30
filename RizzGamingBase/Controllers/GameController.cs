using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.Infra;
using RizzGamingBase.Models.Interfaces;
using RizzGamingBase.Models.Repositories.EFRepositories;
using RizzGamingBase.Models.Services;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace RizzGamingBase.Controllers
{
    public class GameController : Controller
    {
		
		// GET: Game
		public ActionResult Index()
		{
			IGameRepository repo = new GameEFRepository();
			GameService service = new GameService(repo);
			List<GameIndexVm> vm = service.Filter().ToGameVm(); //顯示全部
			return View(vm);
		}

		//[Authorize]
		public ActionResult Edit(int id = 2)
		{
			IGameRepository repo = new GameEFRepository();
			GameService service = new GameService(repo);

			var game = service.Search(id);
			DeveloperGameEditVm vm = game.ToDGVm();
			return View(vm);
		}

		//[Authorize]
		[HttpPost]
		public ActionResult Edit(DeveloperGameEditVm vm, HttpPostedFileBase cover, IEnumerable<HttpPostedFileBase> displayImage, IEnumerable<HttpPostedFileBase> displayVideo)
		{
			IGameRepository repo = new GameEFRepository();
			GameService service = new GameService(repo);

			string displayImagePath = Server.MapPath("/Image/DisplayImage");
			string coverPath = Server.MapPath("/Image/Cover");
			string displayVideoPath = Server.MapPath("/Image/DisplayVideo");

			service.DGSave(vm, displayImagePath, coverPath, displayVideoPath);
			return RedirectToAction("Index");

			
		}

		//[Authorize]
		public ActionResult Create()
		{
			IGameRepository repo = new GameEFRepository();
			GameService service = new GameService(repo);

			var tagList = service.GetAllTag();


			return View();
		}

		//[Authorize]
		[HttpPost]
		public ActionResult Create(DeveloperGameEditVm vm, HttpPostedFileBase cover, IEnumerable<HttpPostedFileBase> displayImage, IEnumerable<HttpPostedFileBase> displayVideo)
		{
			IGameRepository repo = new GameEFRepository();
			GameService service = new GameService(repo);

			if (!ModelState.IsValid) { return View(vm); };

				string displayImagePath = Server.MapPath("/Image/DisplayImage");
				string coverPath = Server.MapPath("/Image/Cover");
				string displayVideoPath = Server.MapPath("/Image/DisplayVideo");

			try
			{
				//string coverName = new UploadFileHelper().UploadCoverFile(cover ,coverPath , vm.DeveloperId, vm.Id);
				//string displayImageName = new UploadFileHelper().UploadDisplayImageFile(displayImage, displayImagePath, vm.DeveloperId, vm.Id);
				//string displayVideoName = new UploadFileHelper().UploadDisplayVideoFile(displayVideo, displayVideoPath, vm.DeveloperId, vm.Id);
			

				service.Create(vm, displayImagePath, coverPath, displayVideoPath, cover , displayImage, displayVideo);
				return RedirectToAction("Index");
			}
			catch (Exception ex) 
			{
				ModelState.AddModelError(string.Empty, ex.Message); 
			}
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
			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult CoverScratchAsync(IEnumerable<HttpPostedFileBase> files)
		{
			string scratchPath = Server.MapPath("~/Image/Scratch");
			var uploadFileHelper = new UploadFileHelper();
			try
			{
				var result = uploadFileHelper.ScratchFile(files, scratchPath);

				return Json(new { success = true, message = "File uploaded successfully.", images = result });
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = ex.Message });
			}
		}

		[HttpPost]
		public ActionResult DeleteCoverScratchAsync(dynamic files)
		{
			string scratchPath = Server.MapPath("~/Image/Scratch");
			var uploadFileHelper = new UploadFileHelper();
		
			uploadFileHelper.DeleteScratchFile(files, scratchPath);

			return Json(new { success = true, message = "Files deleted successfully." });
			//return View();

		}
	}
}
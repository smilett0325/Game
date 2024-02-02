using Microsoft.SqlServer.Server;
using RizzGamingBase.Models.EFModels;
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
using System.Security.Cryptography.X509Certificates;
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
			//var db = new AppDbContext();
			//var game = db.Games.Where(x=> x.Id == 5 ).FirstOrDefault();
			IGameRepository repo = new GameEFRepository();
			GameService service = new GameService(repo);

			var tagList = service.GetAllTag();
			ViewBag.TagList = tagList;
			var gameList = service.Filter();
			ViewBag.gameList = gameList;
			return View();
		}

		//[Authorize]
		[HttpPost]
		public ActionResult Create(DeveloperGameEditVm vm, HttpPostedFileBase cover, IEnumerable<HttpPostedFileBase> displayImages, HttpPostedFileBase displayVideo)
		{
			IGameRepository repo = new GameEFRepository();
			GameService service = new GameService(repo);
			
			var tagList = service.GetAllTag();
			ViewBag.TagList = tagList;
			var gameList = service.Filter();
			ViewBag.gameList = gameList;

			string[] selectedTags = Request.Form.GetValues("selectedTags[]");			
			string[] attachedGame = Request.Form.GetValues("selectedGame");

			if (!ModelState.IsValid) { return View(vm); };

			//string displayImagePath = Server.MapPath("/Images/DisplayImages");
			//string coverScratchPath = Server.MapPath("/Images/Scratch/Cover");
			//string displayVideoScratchPath = Server.MapPath("/Images/Scratch/DisplayVideo");

			//getDeveloperId， 尚未實作
			int developerId = 1; 

			try
			{
				service.Create(vm, developerId, cover , displayImages, displayVideo, selectedTags, attachedGame);
				//return RedirectToAction("Index");
				var result = new { success = true, message = "操作成功" };

				return Json(result);
			}
			catch (Exception ex) 
			{
				ModelState.AddModelError(string.Empty, ex.Message); 
			}
			
			return RedirectToAction("Index");
		}
	}
}
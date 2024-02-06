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
			string developerAccount = User.Identity.Name;
			var db = new AppDbContext();
			int? developerId = db.Developers.Where(x=> x.Account == developerAccount).Select(x => x.Id).FirstOrDefault();
			 
			IGameRepository repo = new GameEFRepository();
			GameService service = new GameService(repo);
			if(developerId == 0)
			{
				List<GameIndexVm> vm = service.Filter().ToGameVm(); //顯示全部
				return View(vm);
			}
			else 
			{	
				return RedirectToAction("DeveloperIndex");
			}
		}
		public ActionResult DeveloperIndex()
		{
			IGameRepository repo = new GameEFRepository();
			GameService service = new GameService(repo);
			string developerAccount = User.Identity.Name;
			var db = new AppDbContext();
			int? developerId = db.Developers.Where(x => x.Account == developerAccount).Select(x => x.Id).FirstOrDefault();
			List<GameIndexVm> vm2 = service.FilterByDeveloper(developerId).ToGameVm();
			return View(vm2);
		}

		//[Authorize]
		public ActionResult Edit(int id)
		{
			IGameRepository repo = new GameEFRepository();
			GameService service = new GameService(repo);

			var tagList = service.GetAllTag();
			ViewBag.tagList = tagList;
			var gameList = service.Filter(x => x.Id != id).ToList();
			ViewBag.gameList = gameList;

			//ViewBag SelectedTag
			var selectedTags = service.GetSelectedTags(id);
			ViewBag.selectedTags = selectedTags;

			//ViewBag SelectedDLC
			var attachedGame = service.GetAttachedGame(id);
			ViewBag.attachedGame = attachedGame;

			var game = service.Search(id);
			DeveloperGameEditVm vm = game.ToDGVm();
			return View(vm);
		}

		[HttpPost]
		public ActionResult Update(DeveloperGameEditVm vm, HttpPostedFileBase cover, IEnumerable<HttpPostedFileBase> displayImages, HttpPostedFileBase displayVideo)
		{
			IGameRepository repo = new GameEFRepository();
			GameService service = new GameService(repo);

			if (!ModelState.IsValid) { return View(vm); };
			int developerId = 1;

			string[] selectedTags = Request.Form.GetValues("selectedTags[]");
			string[] attachedGame = Request.Form.GetValues("selectedGame");
			string[] originalImages = Request.Form.GetValues("originalImages");


			try
			{

				service.Save(vm, developerId, cover, displayImages, displayVideo, selectedTags, attachedGame,originalImages);
				var result = new { success = true, message = "操作成功" };

				return Json(result);
			}
			catch(Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
			}
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
		public ActionResult CreateGame(DeveloperGameEditVm vm, HttpPostedFileBase cover, IEnumerable<HttpPostedFileBase> displayImages, HttpPostedFileBase displayVideo)
		{
			IGameRepository repo = new GameEFRepository();
			GameService service = new GameService(repo);
			string developerAccount = User.Identity.Name;
			var db = new AppDbContext();
			int developerId = db.Developers.Where(x => x.Account == developerAccount).Select(x => x.Id).FirstOrDefault();

			string[] selectedTags = Request.Form.GetValues("selectedTags[]");			
			string[] attachedGame = Request.Form.GetValues("selectedGame");

			if (!ModelState.IsValid) { return View(vm); };

			//getDeveloperId， 尚未實作
			

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
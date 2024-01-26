using RizzGameBase.Models.Exts;
using RizzGameBase.Models.IRepositories;
using RizzGameBase.Models.IServices;
using RizzGameBase.Models.Repositories.EFRepository;
using RizzGameBase.Models.Services;
using RizzGameBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RizzGameBase.Controllers
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
		public ActionResult Edit(int id)
		{
			IGameRepository repo = new GameEFRepository();
			GameService service = new GameService(repo);
			
			var game = service.Search(id);
			DeveloperGameEditVm vm = game.ToDGVm();
			return View(vm);
		}

		//[Authorize]
		[HttpPost]
		public ActionResult Edit(DeveloperGameEditVm vm)
		{
			return RedirectToAction("Index");
		}

		[Authorize]
		public ActionResult Create()
		{
			return View();
		}

		[Authorize]
		[HttpPost]
		public ActionResult Create(DeveloperGameEditVm vm)
		{
			return RedirectToAction("Index");
		}
	}
}
using System;
using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.Entity;
using RizzGamingBase.Models.Exts;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RizzGamingBase.Models.Services;
using RizzGamingBase.Models.Repositories;
using RizzGamingBase.Models.InterFaces;
using System.Web.Http;
using RizzGamingBase.Models.ViewModels;
using RizzGamingBase.Models.EFModels;

namespace RizzGamingBase.Controllers
{
	public class GameDataController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Chart()
		{
			// 获取数据（示例数据）
			List<decimal> Linedata = GetLineDataFromDatabase();
			List<GameDataVm> Piedata = GetPieDataFromDatabase();
			// 转换数据格式
			ViewBag.LineChartData = string.Join(",", Linedata);
			ViewBag.PieChartData = Piedata;

			return View();
		}

		public ActionResult LineChart()
		{
			var service = new GameDataService(GetRepository());
			// 获取数据（示例数据）
			List<decimal> Linedata = GetLineDataFromDatabase();
			// 转换数据格式
			ViewBag.LineChartData = string.Join(",", Linedata);
			ViewBag.DeveloperList = SelectListExts.GetSelectListItems(service);
			return View();
		}

		public ActionResult PieChart()
		{
			var service = new GameDataService(GetRepository());
			// 获取数据（示例数据）
			List<GameDataVm> Piedata = GetPieDataFromDatabase();
			// 转换数据格式
			ViewBag.PieChartData = Piedata;
			ViewBag.DeveloperList = SelectListExts.GetSelectListItems(service);

			return View();
		}

		public List<decimal> GetLineDataFromDatabase(string gameName ="",int year =2023)
		{
			// 使用ADO.NET从数据库中检索数据的逻辑
			var service = new GameDataService(GetRepository());
			
			var dataList = service.SearchGameName(gameName,year);

			// 返回示例数据
			return dataList;
		}

		public List<GameDataVm> GetPieDataFromDatabase()
		{
			// 使用ADO.NET从数据库中检索数据的逻辑
			var service = new GameDataService(GetRepository());

			//var id = 1;
			//var dataList = service.SearchGames(id);

			var dataList = service.SearchDevelopers();

			var data = GameDataExts.DtoToIndexVm(dataList);
			// 返回示例数据
			return data;
		}



		[System.Web.Mvc.HttpPost]
		public ActionResult GetLineDataFromDatabase(int year)
		{
			var gameName = "";
			// 使用 model.GameName 進行處理
			var service = new GameDataService(GetRepository());
			var dataList = service.SearchGameName(gameName, year);

			// 返回示例數據，這裡你可以返回JSON結果或者視圖
			return Json(dataList);
		}
		[System.Web.Mvc.HttpPost]
		public ActionResult GetLineDataFromDatabaseDeveloperId(int year, int developerId)
		{
			// 使用 model.GameName 進行處理
			var service = new GameDataService(GetRepository());
			var dataList = service.SearchDeveloperBi(developerId, year);

			// 返回示例數據，這裡你可以返回JSON結果或者視圖
			return Json(dataList);
		}
		[System.Web.Mvc.HttpPost]
		public ActionResult GetLineDataFromDatabaseGameName(int year, string gameName)
		{
			var GameName = gameName;
			
			// 使用 model.GameName 進行處理
			var service = new GameDataService(GetRepository());
			var dataList = service.SearchGameName(GameName, year);

			// 返回示例數據，這裡你可以返回JSON結果或者視圖
			return Json(dataList);
		}

		[System.Web.Mvc.HttpPost]
		public ActionResult GetPieDataFromDatabase(int id)
		{
			// 使用ADO.NET从数据库中检索数据的逻辑
			var service = new GameDataService(GetRepository());

			var dataList = service.SearchGames(id);

			// 返回示例数据
			return Json(dataList);
		}

		[System.Web.Mvc.HttpPost]
		public ActionResult loadDeveloperDatas(int id)
		{
			// 使用ADO.NET从数据库中检索数据的逻辑
			var service = new GameDataService(GetRepository());

			var dataList = SelectListExts.GetSelectListItemsDeveloper(service,id);

			// 返回示例数据
			return Json(dataList);
		}



		private IGameDataRepository GetRepository()
		{
			return new GameDataEFRepository();
		}
	}
}
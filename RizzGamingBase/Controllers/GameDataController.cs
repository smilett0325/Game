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
			List<decimal> data = GetLineDataFromDatabase();
			// 转换数据格式
			ViewBag.BarChartData = string.Join(",", data);

			return View();
		}

		public ActionResult LineChart()
		{
			// 获取数据（示例数据）
			List<decimal> data = GetLineDataFromDatabase();
			// 转换数据格式
			ViewBag.BarChartData = string.Join(",", data);

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




		private IGameDataRepository GetRepository()
		{
			return new GameDataEFRepository();
		}
	}
}
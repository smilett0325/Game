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
			List<decimal> data = GetBarDataFromDatabase();
			// 转换数据格式
			ViewBag.BarChartData = string.Join(",", data);

			return View();
		}

		private List<decimal> GetBarDataFromDatabase()
		{
			// 使用ADO.NET从数据库中检索数据的逻辑
			var service = new GameDataService(GetRepository());
			var gameName = "遊戲1";

			var dataList = service.SearchGameName(gameName);


			// 返回示例数据
			return dataList;
		}

		private IGameDataRepository GetRepository()
		{
			return new GameDataEFRepository();
		}
	}
}
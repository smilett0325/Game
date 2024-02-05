using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using RizzGamingBase.Models.Services;
using RizzGamingBase.Models.Repositories;
using RizzGamingBase.Models.Interfaces;
using System.Web.Http;
using RizzGamingBase.Models.ViewModels;
using RizzGamingBase.Models.EFModels;
using System.Data;
using System.Web.UI.WebControls;
using RizzGamingBase.Models.Entities;

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

			int Data7T = GetData7T();
			decimal Data7A = GetData7A();
			int Data30T = GetData30T();
			decimal Data30A = GetData30A();
			// 转换数据格式
			ViewBag.LineChartData = string.Join(",", Linedata);
			ViewBag.PieChartData = Piedata;

			ViewBag.Data7T = Data7T;
			ViewBag.Data7A = Data7A;
			ViewBag.Data30T = Data30T;
			ViewBag.Data30A = Data30A;


			return View();
		}

		public ActionResult DChart(int id=1)
		{
			// 获取数据（示例数据）
			List<decimal> Linedata = GetDeveloperIdLineDataFromDatabase(id);
			List<GameDataVm> Piedata = GetDeveloperIdPieDataFromDatabase(id);

			int Data7T = GetData7T(id);
			decimal Data7A = GetData7A(id);
			int Data30T = GetData30T(id);
			decimal Data30A = GetData30A(id);
			// 转换数据格式
			ViewBag.LineChartData = string.Join(",", Linedata);
			ViewBag.PieChartData = Piedata;

			ViewBag.Data7T = Data7T;
			ViewBag.Data7A = Data7A;
			ViewBag.Data30T = Data30T;
			ViewBag.Data30A = Data30A;


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

		public ActionResult DLineChart(int id=1)
		{
			var service = new GameDataService(GetRepository());
			// 获取数据（示例数据）
			List<decimal> Linedata = GetDeveloperIdLineDataFromDatabase(id);
			// 转换数据格式
			ViewBag.LineChartData = string.Join(",", Linedata);
			ViewBag.DeveloperList = SelectListExts.GetSelectListItemsDeveloper(service,id);
			ViewBag.Id = id;
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

		public ActionResult DPieChart(int id=1)
		{
			var service = new GameDataService(GetRepository());
			// 获取数据（示例数据）
			List<GameDataVm> Piedata = GetDeveloperIdPieDataFromDatabase(id);
			// 转换数据格式
			ViewBag.PieChartData = Piedata;

			return View();
		}

		public List<decimal> GetLineDataFromDatabase(int year =2023)
		{
			// 使用ADO.NET从数据库中检索数据的逻辑
			var service = new GameDataService(GetRepository());
			
			var dataList = service.SearchAllGameBi(year);

			// 返回示例数据
			return dataList;
		}

		public List<decimal> GetDeveloperIdLineDataFromDatabase( int developerId, int year = 2023)
		{
			// 使用 model.GameName 進行處理
			var service = new GameDataService(GetRepository());
			var dataList = service.SearchDeveloperBi(developerId, year);

			// 返回示例數據，這裡你可以返回JSON結果或者視圖
			return dataList;
		}

		public int GetData7T(int id = 0)
		{
			var service = new GameDataService(GetRepository());
			int days = 7;

			var data = service.SearchBisToTimes(id, days);

			return data;
		}

		public decimal GetData7A(int id = 0)
		{
			var service = new GameDataService(GetRepository());
			int days = 7;

			var data = service.SearchBisToAmouts(id,days);

			return data;
		}
		public int GetData30T(int id = 0)
		{
			var service = new GameDataService(GetRepository());
			int days = 30;

			var data = service.SearchBisToTimes(id, days);

			return data;
		}

		public decimal GetData30A(int id = 0)
		{
			var service = new GameDataService(GetRepository());
			int days = 30;

			var data = service.SearchBisToAmouts(id, days);

			return data;
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

		public List<GameDataVm> GetDeveloperIdPieDataFromDatabase(int id)
		{
			// 使用ADO.NET从数据库中检索数据的逻辑
			var service = new GameDataService(GetRepository());

			var dataList = GameDataExts.DtoToIndexVm(service.SearchGames(id));

			// 返回示例数据
			return dataList;
		}



		[System.Web.Mvc.HttpPost]
		public ActionResult GetLineDataFromDatabaseYear(int year)
		{

			// 使用 model.GameName 進行處理
			var service = new GameDataService(GetRepository());
			var dataList = service.SearchAllGameBi(year);
			//var dataList = service.SearchGameName(gameName, year);

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
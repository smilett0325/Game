using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RizzGamingBase.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
			var db = new AppDbContext();

			return View(db.Members.ToList());
		}

		public ActionResult Create()
		{
			return View();
		}

		public ActionResult Edit()
		{
			return View();
		}

        public ActionResult ReportList()
        {
            return View();
        }
    }
}
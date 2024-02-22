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
        private readonly AppDbContext _db = new AppDbContext();
        // GET: Member
        public ActionResult MemberIndex()
        {
			return View(_db.Members.ToList());
		}

        public ActionResult MemberReportList()
        {
            return View();
        }
    }
}
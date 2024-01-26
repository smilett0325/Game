using RizzGameingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RizzGameingBase.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members  
        //實作網頁的地方
        public ActionResult Index()
        {
            List<MemberIndexVm> data = GetAll();
            return View();
        }

		private List<MemberIndexVm> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
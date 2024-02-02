﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RizzGamingBase.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		[AllowAnonymous]
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";

			return View();
		}
	}
}

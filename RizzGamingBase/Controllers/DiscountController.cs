using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RizzGamingBase.Controllers
{
    public class DiscountController : Controller
    {
        // GET: Discount
        public ActionResult Index()
        {
            List<DiscountIndexVm> vm = DiscountActionExts.GetAllEvent();
            return View(vm);
        }

        public ActionResult Edit(int id)
        {
            DiscountVm vm = DiscountActionExts.GetEvent(id);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DiscountVm vm)
        {
            if(!ModelState.IsValid) return View(vm);
            try
            {
                DiscountActionExts.Edit(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }

            return RedirectToAction("Index");
        }
        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DiscountCreateVm vm) 
        {

            if (!ModelState.IsValid) return View(vm);

            try
            {
                DiscountActionExts.Create(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }

            return RedirectToAction("Index");
        }

       
    }
}
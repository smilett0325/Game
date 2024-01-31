using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Security.Cryptography;

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
            var model = new DiscountCreateVm
            {
                DiscountTypeList = GetDiscountTypeList(),
            };
            return View(model);
        }


        private IEnumerable<SelectListItem> GetDiscountTypeList()
        {
            return new List<SelectListItem>
            {
            new SelectListItem { Value = "季度特價", Text = "季度特價" },
            new SelectListItem { Value = "自訂特價", Text = "自訂特價" },
            
            };
        }

        [HttpPost]
        public ActionResult Create(DiscountCreateVm vm) 
        {

            if (!ModelState.IsValid) 
            {
                vm.DiscountTypeList = GetDiscountTypeList();
                return View(vm); 
            }

            try
            {
                DiscountActionExts.Create(vm);
            }
            catch (Exception ex)
            {
                if (vm.StartDate.Date < DateTime.Now.Date)
                {
                    ModelState.AddModelError("StartDate", "开始日期不能选择已经过了的日期");
                    vm.DiscountTypeList = GetDiscountTypeList();
                    ModelState.AddModelError("", ex.Message);
                    return View(vm);
                }
        
            }

            return RedirectToAction("Index");
        }











     
        public ActionResult AddItem(int id, int gameId)
        {
            var db = new AppDbContext();

            var item = db.DiscountItems.FirstOrDefault(x => x.DiscountId == id  && x.GameId == gameId );
            if( item == null)
            {
                var newItem = new DiscountItem
                {
                    DiscountId = id,
                    GameId = gameId,
                };
                db.DiscountItems.Add(newItem);
                db.SaveChanges();
                return new EmptyResult();
            }

            
            return new EmptyResult();
        }

        public JsonResult AddNewItem(int gameId)
        {
            var db = new AppDbContext();

            var item = db.Games.FirstOrDefault(d => d.Id == gameId);

            if(item != null)
            {
                var game = new DiscountGameVm
                {
                    Id = item.Id,
                    Name = item.Name,
                    Developer = item.Developer.Name,
                    Price = item.Price,
                    Image = item.Image,
                    MaxPercent = item.MaxPersent

                };
                return Json(game, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }


        public JsonResult DelNewItem(int gameId)
        {
            var db = new AppDbContext();


            var item = db.Games.FirstOrDefault(x => x.Id == gameId);
            if (item != null)
            {
                var game = new DiscountGameVm
                {
                    Id = item.Id,
                    Name = item.Name,
                    Developer = item.Developer.Name,
                    Price = item.Price,
                    Image = item.Image,
                    MaxPercent = item.MaxPersent

                };
                return Json(game, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DelItem(int id, int gameId)
        {
            var db = new AppDbContext();


            var item = db.DiscountItems.FirstOrDefault(x => x.DiscountId == id && x.GameId == gameId);
            if (item != null)
            {          
                db.DiscountItems.Remove(item);
                db.SaveChanges();
                return new EmptyResult();
            }


            return new EmptyResult();
        }



        public JsonResult GetDiscountGames(int id)
        {
            var db = new AppDbContext();

            var discountgames = db.DiscountItems
                                  .Include(d => d.Game)
                                  .Where(d => d.DiscountId == id)
                                  .Select(d => new DiscountGameVm
                                  {
                                      Id = d.GameId,
                                      Name = d.Game.Name,
                                      Developer = d.Game.Developer.Name,
                                      Price = d.Game.Price,
                                      Image = d.Game.Image,
                                      MaxPercent = d.Game.MaxPersent
                                  }).ToList();

            return Json(discountgames, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetGames(int id)
        {
            var db = new AppDbContext();

            var allgames = db.Games.AsNoTracking()
                                .Include(d => d.DiscountItems)
                                .Select(d => new DiscountGameVm
                                {
                                    Id = d.Id,
                                    Name = d.Name,
                                    Developer = d.Developer.Name,
                                    Price = d.Price,
                                    Image = d.Image,
                                    MaxPercent = d.MaxPersent
                                }).ToList();

            var discountgames = db.DiscountItems
                                  .Include(d => d.Game)
                                  .Where(d => d.DiscountId == id)
                                  .Select(d => new DiscountGameVm
                                  {
                                      Id = d.GameId,
                                      Name = d.Game.Name,
                                      Developer = d.Game.Developer.Name,
                                      Price = d.Game.Price,
                                      Image = d.Game.Image,
                                      MaxPercent = d.Game.MaxPersent
                                  }).ToList();

            var games = allgames.Except(discountgames).ToList();

            return Json(games, JsonRequestBehavior.AllowGet);
        }

        
    }
}
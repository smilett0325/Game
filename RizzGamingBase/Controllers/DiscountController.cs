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
using Microsoft.Ajax.Utilities;


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


        public ActionResult Home()
        {
            
            return View();
        }

        public ActionResult Edit(int id)
        {
            DiscountVm vm = DiscountActionExts.GetEvent(id);
            vm.DiscountTypeList = GetDiscountTypeList();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DiscountVm vm)
        {
            if (!ModelState.IsValid)
            {
                vm.DiscountTypeList = GetDiscountTypeList();
                return View(vm);
            }
            try
            {
                DiscountActionExts.Edit(vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                vm.DiscountTypeList = GetDiscountTypeList();
                return View(vm);
            }

            return RedirectToAction("Index");
        }
        public ActionResult Create() 
        {
            var model = new DiscountVm
            {
                DiscountTypeList = GetDiscountTypeList(),
            };
            return View(model);
        }


       

        [HttpPost]
        public ActionResult CreateDiscount(DiscountVm vm , HttpPostedFileBase DiscountImage) 
        {

            if (!ModelState.IsValid) 
            {
                vm.DiscountTypeList = GetDiscountTypeList();
                return View(vm); 
            }

            try
            {
                vm.DiscountImage = DiscountImage.FileName;
                DiscountActionExts.Create(vm, DiscountImage);

                var result = new { success = true };
                return Json(result);
            }
            catch (Exception ex)
            {
               
        
            }

            return RedirectToAction("Index");
        }


        private IEnumerable<SelectListItem> GetDiscountTypeList()
        {
            return new List<SelectListItem>
            {
            new SelectListItem { Value = "季度特價", Text = "季度特價" },
            new SelectListItem { Value = "自訂特價", Text = "自訂特價" },

            };
        }











        public JsonResult GetDiscountEvent(int? id)
        {
            var db = new AppDbContext();

            if (id != null) {
                var discountevent = db.Discounts
                                      .Where(d => d.DeveloperId == id)
                                      .Select(d => new DiscountEventVm
                                      {
                                          Id = d.Id,
                                          Name = d.Name,
                                          Type = d.DiscountType,
                                          StartDate = d.StartDate,
                                          EndDate = d.EndDate,
                                          Image = d.Image,
                                      }).ToList();
                return Json(discountevent, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var discountevent = db.Discounts
                                      .Select(d => new DiscountEventVm
                                      {
                                          Id = d.Id,
                                          Name = d.Name,
                                          Type = d.DiscountType,
                                          StartDate = d.StartDate,
                                          EndDate = d.EndDate,
                                          Image = d.Image,
                                      }).ToList();
                return Json(discountevent, JsonRequestBehavior.AllowGet);
            } 
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
                    Image = item.Cover,
                    MaxPercent = item.MaxPercent

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
                    Image = item.Cover,
                    MaxPercent = item.MaxPercent

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
                                      Image = d.Game.Cover,
                                      MaxPercent = d.Game.MaxPercent
                                  }).ToList();

            return Json(discountgames, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetGames(int? id, string keyword)
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
                                    Image = d.Cover,
                                    MaxPercent = d.MaxPercent
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
                                      Image = d.Game.Cover,
                                      MaxPercent = d.Game.MaxPercent
                                  }).ToList();
            
            
            var games = allgames.Except(discountgames).ToList();
            

            if (!string.IsNullOrEmpty(keyword))
            {
                games = games.Where(d => d.Name.Contains(keyword))
                            .ToList();
            }

            return Json(games, JsonRequestBehavior.AllowGet);
        }

        

    }
}
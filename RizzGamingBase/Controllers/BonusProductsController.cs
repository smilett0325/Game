using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.Repositories.EFRepositories;
using RizzGamingBase.Models.Services;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RizzGamingBase.Controllers
{
    public class BonusProductsController : Controller
    {
        // GET: Items
        public ActionResult Index()
        {
            List<BonusProductsIndexVm> data = BonusProductExts.GetAll();//取得表單Data全部的值
            return View(data);
            // todo 圖片字串 插入HTML
        }

        public ActionResult Create()//實作顯示
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BonusProductsCreateVm model)//傳入DB
        {
            if (!ModelState.IsValid) return View(model);
            {
                try
                {
                    BonusProductExts.CreateProduct(model);
                    return RedirectToAction("Index");//生成的物件回傳至 Index 
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                    return View(model);
                }
            }
        }

        public ActionResult Edit(int id)//編輯
        {
            BonusProductsVm model = LoadProdct(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BonusProductsVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            try
            {
                UpdateProduct(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }
            return View(model);
            //尚未實作View
        }

        public BonusProductsVm LoadProdct(int id)//找到編輯欄位
        {
            var repo = new BonusProductsEFRepository();
            var service = new BonusProductsServices(repo);
            var dto = service.LoadProdct(id);
            var model = new BonusProductsVm
            {
                Id = dto.Id,
                ProductTypeid = dto.ProductTypeid,
                Price = dto.Price,
                URL = dto.URL,
                Name = dto.Name
            };
            return model;
        }

        private void UpdateProduct(BonusProductsVm model)//修改
        {
            var repo = new BonusProductsEFRepository();
            var service = new BonusProductsServices(repo);

            BonusProductsDto dto = new BonusProductsDto
            {
                Id = model.Id,
                ProductTypeid = model.ProductTypeid,
                TypeName = model.ProductType,
                Price = model.Price,
                URL = model.URL,
                Name = model.Name
            };
            service.Update(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//驗證，避免偽造網頁刪除
        public ActionResult Delete(int id)
        {
            DeleteProduct(id);
            return RedirectToAction("Index");
        }

        private void DeleteProduct(int id)
        {
            //直接叫用ER。或叫用 Services OBJ
            var db = new AppDbContext();
            var entity = db.BonusProducts.Find(id);
            db.BonusProducts.Remove(entity);
            db.SaveChanges();
        }
    }
}
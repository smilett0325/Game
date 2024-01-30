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
using System.Web.WebSockets;

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

        // todo 關鍵字查詢
        //private List<BonusProductsIndexVm> GetKeyword(string keyword)
        //{
        //    List<BonusProductsIndexVm> searchResults = BonusProductExts.
        //}
        public ActionResult Search(string keyword)
        {
            // Add code here to search for items based on the keyword
            // and return the search results
            return View();
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

        #region 單層編輯
        public ActionResult Edit(int id)//編輯
        {
            BonusProductsEditVm model = LoadProdct(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BonusProductsEditVm model)
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
        }

        public BonusProductsEditVm LoadProdct(int id)//找到編輯欄位
        {
            var model = new AppDbContext().BonusProducts.Find(id);
            return new BonusProductsEditVm
            {
                Id = model.Id,
                ProductTypeId = model.ProductTypeId,
                ProductTypeName = model.BonusProductType.Name,
                Price = model.Price,
                URL = model.URL,
                Name = model.Name
            };
        }

        private void UpdateProduct(BonusProductsEditVm model)//修改
        {
            var db = new AppDbContext();

            var findproduct = db.BonusProducts.Find(model.Id);
            findproduct.Id = model.Id;
            findproduct.ProductTypeId = model.ProductTypeId;
            findproduct.Price = model.Price;
            findproduct.URL = model.URL;
            findproduct.Name = model.Name;

            db.SaveChanges();
        }
        #endregion

        #region 三層編輯
        //todo 三程式架構編輯
        /*
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
            throw new NotImplementedException();
        }

        private void UpdateProduct(BonusProductsVm model)//修改
        {
            throw new NotImplementedException();
        }
        */
        #endregion

        #region 單層刪除
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var db = new AppDbContext();

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);//400錯誤回應
            }
            BonusProduct bonusProduct = db.BonusProducts.Find(id);
            if (bonusProduct == null)
            {
                return HttpNotFound();//找不到頁面
            }
            return View(bonusProduct);//回傳資料
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var db = new AppDbContext();

            BonusProduct bonusProduct = db.BonusProducts.Find(id);
            db.BonusProducts.Remove(bonusProduct);
            db.SaveChanges();
            return RedirectToAction("Index");//返回
        }
        #endregion

        #region 三層刪除
        // todo 三程式架構刪除
        /*
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
        */
        #endregion
    }
}
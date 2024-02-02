using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Exts;
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
        private readonly AppDbContext db;

        public BonusProductsController()
        {
            db = new AppDbContext();
            // todo DB連線using資源釋放尚未完工
            // using (db = new AppDbContext()){/* 初始化 db*/}
        }

        public ActionResult Index()
        {
            List<BonusProductsIndexVm> data = BonusProductExts.GetAll(db);//取得表單Data全部的值
            return View(data);
            // todo 圖片字串 插入HTML
        }

        public ActionResult Search(string keyword)
        {
            List<BonusProductsIndexVm> data = BonusProductExts.SearchByName(keyword, db);//取得表單Data全部的值
            return View();
        }
        public ActionResult Create()//實作顯示
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BonusProductsCreateVm model)//傳入DB
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                BonusProductExts.CreateProduct(model, db);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return View(model);
            }
        }


        #region 單層編輯
        public ActionResult Edit(int id)
        {
            BonusProductsEditVm model = LoadProdct(id);
            var productTypes = db.BonusProductTypes.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name
            }).ToList();
            ViewBag.ProductTypes = productTypes; // 將 productTypes 設置到 ViewBag 中
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            //var model = new AppDbContext().BonusProducts.Find(id);
            //using (var db = new AppDbContext());//using會在連線字串完後自然釋放比上面更省效能也不用擔心資料外洩
            {
                var model = db.BonusProducts.Find(id);
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

        }
        private void UpdateProduct(BonusProductsEditVm model)//修改
        {
            var findProduct = db.BonusProducts.Find(model.Id);
            if (findProduct != null)
            {
                findProduct.ProductTypeId = model.ProductTypeId;
                findProduct.Price = model.Price;
                findProduct.URL = model.URL;
                findProduct.Name = model.Name;

                db.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("並未找到項目");
            }
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
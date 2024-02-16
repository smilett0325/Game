using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.Infra;
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
            // using (db = new AppDbContext()){/* 初始化 db*/}// todo 優化讀取
        }

        public ActionResult Index(string keyword)
        {
            List<BonusProductsIndexVm> data;

            // 如果使用者輸入關鍵字，則顯示符合關鍵字的資料
            if (!string.IsNullOrEmpty(keyword))
            {
                data = BonusProductExts.GetAll(db)
                                       .Where(bp => bp.Name.Contains(keyword)) // 用 Name 當 keyword 篩選
                                       .ToList();
            }
            else
            {
                // 如果使用者未輸入關鍵字，則顯示所有資料
                data = BonusProductExts.GetAll(db);
            }

            return View(data);
            // todo 圖片字串 插入HTML
        }

        public ActionResult Create()//實作顯示
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(BonusProductsCreateVm model , HttpPostedFileBase URL)//傳入DB ///HttpPostedFileBase
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
               
                BonusProductExts.CreateProduct(model, db, URL);
                //return RedirectToAction("Index");
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                //return View(model);
                return Json(new { success = false });
            }
        }


        #region 單層編輯
        #region 舊的程式
        //public BonusProductsEditVm LoadProdct(int id)//找到編輯欄位
        //{
        //    //var model = new AppDbContext().BonusProducts.Find(id);
        //    //using (var db = new AppDbContext());//using會在連線字串完後自然釋放比上面更省效能也不用擔心資料外洩
        //    {
        //        var model = db.BonusProducts.Find(id);
        //        return new BonusProductsEditVm
        //        {
        //            Id = model.Id,
        //            ProductTypeId = model.ProductTypeId,
        //            ProductTypeName = model.BonusProductType.Name,
        //            Price = model.Price,
        //            URL = model.URL,
        //            Name = model.Name
        //        };
        //    }

        //}
        //private void UpdateProduct(BonusProductsEditVm model, HttpPostedFileBase URL)//修改
        //{
        //    var findProduct = db.BonusProducts.Find(model.Id);
        //    var uploadFileHelper = new UploadFileHelper();

        //    if (findProduct != null)
        //    {
        //        string[] imgAllowedExtensions = { ".jpg", ".jpeg", ".png",".gif" };

        //        if (URL != null)
        //        {
        //            uploadFileHelper.DeleteFile("BonusProducts", findProduct.ProductTypeId, findProduct.URL);
        //            uploadFileHelper.UploadFile(URL, "BonusProducts", model.ProductTypeId,  imgAllowedExtensions);
        //        }
        //        findProduct.ProductTypeId = model.ProductTypeId;
        //        findProduct.Price = model.Price;
        //        findProduct.URL = URL != null ? URL.FileName : findProduct.URL ;
        //        findProduct.Name = model.Name;

        //        db.SaveChanges();

        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("並未找到項目");
        //    }
        //}
        #endregion
        #endregion

        //todo 三程式架構編輯
        #region 三層編輯
        public ActionResult Edit(int id)
        {
            //BonusProductsEditVm model = BonusProductExts.LoadProdct(db, id);//也是3層式的寫法，但比起下面的方式直接在控制器使用支料存取方法違反了分層原則
            var model = db.LoadProdct(id);
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
        public ActionResult Edit(BonusProductsEditVm model, HttpPostedFileBase URL)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                //UpdateProduct(model,URL);
                BonusProductExts.UpdateProduct(db, model, URL);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }
            return View(model);
        }

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
            var uploadFileHelper = new UploadFileHelper();
            BonusProduct bonusProduct = db.BonusProducts.Find(id);
            db.BonusProducts.Remove(bonusProduct);
            db.SaveChanges();

            uploadFileHelper.DeleteFile("BonusProducts", bonusProduct.ProductTypeId, bonusProduct.URL);

            return RedirectToAction("Index");//返回
        }
        #endregion

        // todo 三程式架構刪除
        #region 三層刪除
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
using RizzGamingBase.Models;
using RizzGamingBase.Models.EFModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace RizzGamingBase.Controllers
{
    public class ManangerController : Controller
    {
        private AppDbContext db = new AppDbContext();
        
        // GET: Developer
        public ActionResult Index()
        {
            return View(db.Developers.ToList());
        }

        // GET: Developer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developer developer = db.Developers.Find(id);
            if (developer == null)
            {
                return HttpNotFound();
            }
            return View(developer);
        }

        // GET: Developer/Create
        public ActionResult Login()
        {
            return View();
        }

        // POST: Developer/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Id,Name,Account,Password,Mail,Number")] Developer developer)
        {
            if (ModelState.IsValid)
            {
                db.Developers.Add(developer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(developer);
        }

        // GET: Developer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Developer developer = db.Developers.Find(id);
            if (developer == null)
            {
                return HttpNotFound();
            }
            return View(developer);
        }

        // POST: Developer/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Account,Password,Mail,Number,BanTime,IsBaned")] Developer developer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(developer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(developer);
        }

        // GET: Developer/Delete/5
        public ActionResult IsBan(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Developer developer = db.Developers.Find(id);

            if (developer == null)
            {
                return HttpNotFound();
            }

            // 在這裡將開發人員的帳戶標記為停用或者從系統中移除
            developer.BanTime = DateTime.UtcNow.AddDays(1); // 將 BanTime 設置為當前時間的一天後

            // 將更改保存到資料庫
            db.SaveChanges();

            return RedirectToAction("Index"); // 導向到開發人員列表或其他適當的頁面
        }

        // POST: Developer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IsBanConfirmed(int id)
        {
            // 在 POST 操作中，你仍然可以執行刪除操作，或者你也可以僅將帳戶停權，根據實際需求
            Developer developer = db.Developers.Find(id);

            if (developer != null)
            {
                // 如果帳戶存在，將 BanTime 設置為當前時間的一天後
                developer.BanTime = DateTime.UtcNow.AddDays(1);

                // 將更改保存到資料庫
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

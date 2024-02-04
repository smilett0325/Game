using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RizzGamingBase.Controllers
{
    public class AdminController : Controller
    {
        private AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {    
            return View(db.Developers.ToList());
        }

        [HttpGet]
        // GET: Admin/Delete/{developerId}
        public ActionResult Delete(int? developerId)
        {
            var AppDbContext = new AppDbContext();
            var db = AppDbContext;

            if (developerId == null)
            {
                // 如果 developerId 為空.返回錯誤或重新導向
                return RedirectToAction("Index");
            }

            // 根據 developerId 從資料庫中獲取開發者信息
            Developer developer = db.Developers.Find(developerId);

            if (developer == null)
            {
                // 如果找不到開發者，返回錯誤或重新導向
                return RedirectToAction("Index");
            }

            // 將開發者信息傳遞給視圖
            return View(developer);
        }

        // POST: Admin/Delete/{developerId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int developerId, DateTime banTime)
        {
            var AppDbContext = new AppDbContext();
            var db = AppDbContext;
            try
            {
                // 根據 developerId 從資料庫中獲取開發者信息
                Developer developer = db.Developers.Find(developerId);

                if (developer == null)
                {
                    // 如果找不到開發者，返回錯誤或重新導向
                    return RedirectToAction("Index");
                }

                // 將 banTime 存入資料庫中的 BanTime 欄位
                developer.BanTime = banTime;

                // 保存變更
                db.SaveChanges();

                // 停權成功後，重新導向到 Index 或其他頁面
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // 處理例外情況，例如記錄錯誤訊息
                ViewBag.ErrorMessage = "發生錯誤: " + ex.Message;

                // 返回原視圖，讓用戶重新輸入
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(MLoginVm vm)
        {
            if (!ModelState.IsValid) // 如果欄位驗證失敗, 就回到 lgoin page
            {
                return View(vm);
            }

            try
            {
                ValidLogin(vm); // 驗證帳密是否ok,且是有效的會員
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }

            var processResult = ProcessLogin(vm); // 將相關資訊(如帳號)準備好並回傳

            Response.Cookies.Add(processResult.Cookie); // 將回傳的 cookie 加到Browser

            return Redirect("/Admin/Index"); // 轉向到它原本應該要去的網址
        }

        private (string ReturnUrl, HttpCookie Cookie) ProcessLogin(MLoginVm vm) // value tuple 元組
        {
            var rememberMe = false; // 如果LoginVm有RememberMe屬性, 記得要設定
            var account = vm.Account;
            var roles = string.Empty; // 在本範例, 沒有用到角色權限,所以存入空白

            // 建立一張認證票
            var ticket =
                new FormsAuthenticationTicket(
                    1,          // 版本別, 沒特別用處
                    account,
                    DateTime.Now,   // 發行日
                    DateTime.Now.AddDays(2), // 到期日
                    rememberMe,     // 是否續存
                    roles,          // userdata
                    "/" // cookie的位置
                );

            // 存入cookie
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName);

            // 取得return url
            var url = FormsAuthentication.GetRedirectUrl(account, true); //第二個引數沒有用處

            return (url, cookie);

        }

        private void ValidLogin(MLoginVm vm)
        {
            var db = new AppDbContext();

            // 根據account(帳號)取得 Developer
            var admin = db.Admins.FirstOrDefault(a => a.Account == vm.Account);
            if (admin == null)
            {
                throw new Exception("帳號或密碼有誤");// 原則上, 不要告知細節
            }


        }
    }
}
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RizzGamingBase.Models;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Exts;
using RizzGamingBase.Models.Infra;
using RizzGamingBase.Models.ViewModels;
using RizzGamingBase.Models.ViewModels.Developer;

namespace RizzGamingBase.Controllers
{
    public class DeveloperController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
                return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterVm model)
        {
            if (!ModelState.IsValid) //沒有通過驗證
            {
                return View(model);
            }
            try
            {
                RegisterDeveloper(model);
                return View("RegisterConfirm");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        private void RegisterDeveloper(RegisterVm vm)
        {

            var db = new AppDbContext();

            // 判斷帳號是否已經存在
            var developerInDb = db.Developers.FirstOrDefault(d => d.Account == vm.Account);
            if (developerInDb != null)
            {
                throw new Exception("帳號已經存在");
            }

            // 將 vm 轉成 Developer
            Developer developer = vm.ToEFModel();

            // 叫用 EF 寫入資料庫
            db.Developers.Add(developer);
            db.SaveChanges();

            // 發出確認信
            var urlTemplate = Request.Url.Scheme + "://" +  // 生成 http:.// 或 https://
                            Request.Url.Authority + "/" + // 生成網域名稱或 ip
                            "Developer/ActiveRegister?developerid={0}&confirmCode={1}";
            var url = string.Format(urlTemplate, developer.Id, developer.ConfirmCode);
            string name = vm.Name;
            string email = vm.EMail;
            new EmailHelper().SendConfirmRegisterEmail(url, name, email);
        }

        public ActionResult ActiveRegister(int developerId, string confirmCode)
        {
            //驗證傳入值是否合理
            
            if (developerId <= 0 || string.IsNullOrEmpty(confirmCode))
            {
                return View(); // 在view中,我們會顯示'已開通,謝謝'
            }

            // 根據 developerId, confirmCode 取得 未確認的 Developer
            Developer developer = GetUnConfirmedDeveloper(developerId, confirmCode);
            if (developer == null) return View();

            // 如果有找到, 將它更新為已確認
            ConfirmDeveloper(developerId);
            return View();
        }

        // 這支method如何實作註冊功能? 直接叫用 EF or 叫用 DeveloperService
       

        private Developer GetUnConfirmedDeveloper(int developerId, string confirmCode)
        {
            return new AppDbContext().Developers.FirstOrDefault(d => d.Id == developerId && d.IsConfirmed == false && d.ConfirmCode == confirmCode);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVm vm)
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

            return Redirect(processResult.ReturnUrl); // 轉向到它原本應該要去的網址
        }

        [Authorize]
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return Redirect("/Developer/Login");
        }

        [Authorize]
        public ActionResult EditProfile()
        {
            var currentUserAccount = User.Identity.Name;
            var vm = GetDeveloperProfile(currentUserAccount);

            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditProfile(EditProfileVm vm)
        {
            var currentUserAccount = User.Identity.Name;
            if (!ModelState.IsValid) return View(vm);

            try
            {
                UpdateProfile(vm, currentUserAccount);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }
            return RedirectToAction("Index"); // 回到會員中心頁
        }

        [Authorize]
        public ActionResult EditPassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPassword(EditPasswordVm vm)
        {
            if (!ModelState.IsValid) return View(vm);
            try
            {
                var currentAccount = User.Identity.Name;
                ChangePassword(vm, currentAccount);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(ForgetPasswordVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var urlTemplate = Request.Url.Scheme + "://" +  // TODO:生成 http:.// 或 https://
                              Request.Url.Authority + "/" + // 生成網域名稱或 ip
                              "Developer/ResetPassword?developerid={0}&confirmCode={1}"; // 生成網頁 url
            try
            {
                ProcessResetPassword(vm.Account, vm.Mail, urlTemplate);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }
            return View("ForgetPasswordConfirm");
        }

        /// <summary>
        /// 重設密碼, 使用者經由信件裡的超連結而來,並不是在網站裡提供本網址
        /// </summary>
        /// <param name="developerId"></param>
        /// <param name="confirmCode"></param>
        /// <returns></returns>
        public ActionResult ResetPassword(int developerId, string comfirmCode)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(int developerId, string confirmCode, ResetPasswordVM vm)
        {
            // 檢查 vm 是否通過驗證
            if (!ModelState.IsValid) return View(vm);
            try
            {
                ProcessResetPassword(developerId, confirmCode, vm);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }
            // 顯示重設密碼成功畫面
            return View("ConfirmResetPassword");
        }

        /// <summary>
        /// 基於安全考量, 若 developerId, confirmCode有錯, 都不會顯示錯誤訊息, 只會顯示重設密碼畫面
        /// </summary>
        /// <param name="developerId"></param>
        /// <param name="confirmCode"></param>
        /// <param name="vm"></param>
        private void ProcessResetPassword(int developerId, string confirmCode, ResetPasswordVM vm)
        {
            var db = new AppDbContext();
            // 檢查 developerId, confirmCode 是否正確
            var developerInDb = db.Developers.FirstOrDefault(d => d.Id == developerId &&
                                                        d.IsConfirmed == true &&
                                                        d.ConfirmCode == confirmCode);
            if (developerInDb == null) return; // 不動聲色的離開

            // 重設密碼
            var salt = HashUtility.GetSalt();
            var hashedPassword = HashUtility.ToSHA256(vm.Password, salt);
            developerInDb.EncryptedPassword = hashedPassword;
            developerInDb.ConfirmCode = null;
            db.SaveChanges();
        }


        private void ProcessResetPassword(string account, string email, string urlTemplate)
        {
            var db = new AppDbContext();
            // 檢查account,email正確性
            var developerInDb = db.Developers.FirstOrDefault(d => d.Account == account);
            if (developerInDb == null) throw new Exception("帳號不存在");
            if (string.Compare(email, developerInDb.EMail, StringComparison.CurrentCultureIgnoreCase) != 0) throw new Exception("帳號或 Email 錯誤");

            // 檢查 IsConfirmed必需是true, 因為只有已啟用的帳號才能重設密碼
            if (developerInDb.IsConfirmed == false) throw new Exception("您還沒有啟用本帳號, 請先完成才能重設密碼");

            // 更新記錄, 填入 confirmCode
            var confirmCode = Guid.NewGuid().ToString("N");
            developerInDb.ConfirmCode = confirmCode;
            db.SaveChanges();

            // 發送重設密碼信
            var url = string.Format(urlTemplate, developerInDb.Id, confirmCode);

            new EmailHelper().SendForgetPasswordEmail(url, developerInDb.Name, email);

        }

        private void ChangePassword(EditPasswordVm vm, string account)
        {
            var db = new AppDbContext();
            var developerInDb = db.Developers.FirstOrDefault(p => p.Account == account);
            if (developerInDb == null) throw new Exception("帳號不存在");

            var salt = HashUtility.GetSalt();

            // 判斷輸入的原始密碼是否正確
            var hashedOrigPassword = HashUtility.ToSHA256(vm.OriginalPassword, salt);
            if (string.Compare(developerInDb.EncryptedPassword, hashedOrigPassword, true) != 0)
            {
                throw new Exception("原始密碼不正確");
            }

            // 將新密碼雜湊
            var hashedPassword = HashUtility.ToSHA256(vm.Password, salt);

            // 更新記錄
            developerInDb.EncryptedPassword = hashedPassword;
            db.SaveChanges();
        }


        private void UpdateProfile(EditProfileVm vm, string account)
        {
            // 利用 vm.Id去資料庫取得 Developer
            var db = new AppDbContext();
            var developerInDb = db.Developers.FirstOrDefault(p => p.Id == vm.Id);

            // 如果這筆記錄與目前使用者不符, 就拒絕
            int result = string.Compare(developerInDb.Account, account, StringComparison.OrdinalIgnoreCase);
            if (result != 0)
            //if (developerInDb.Account != account)
            {
                throw new Exception("您沒有權限修改別人的資料");
            }
            developerInDb.Name = vm.Name;
            developerInDb.EMail = vm.EMail;
            developerInDb.PhoneNumber = vm.PhoneNumber;

            db.SaveChanges();
        }

        private EditProfileVm GetDeveloperProfile(string account)
        {
            var db = new AppDbContext();

            var developer = db.Developers.FirstOrDefault(p => p.Account == account);
            if (developer == null)
            {
                throw new Exception("帳號不存在");
            }

            var vm = developer.ToEditProfileVm();

            return vm;
        }

        private (string ReturnUrl, HttpCookie Cookie) ProcessLogin(LoginVm vm) // value tuple 元組
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
                    "/" // cookie位置
                );

            // 將它加密
            var value = FormsAuthentication.Encrypt(ticket);

            // 存入cookie
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value);

            // 取得return url
            var url = FormsAuthentication.GetRedirectUrl(account, true); //第二個引數沒有用處

            return (url, cookie);

        }

        private void ValidLogin(LoginVm vm)
        {
            var db = new AppDbContext();

            // 根據account(帳號)取得 Developer
            var developer = db.Developers.FirstOrDefault(p => p.Account == vm.Account);
            if (developer == null)
            {
                throw new Exception("帳號或密碼有誤");// 原則上, 不要告知細節
            }

            // 檢查是否已經確認
            if (developer.IsConfirmed == false)
            {
                throw new Exception("您尚未開通會員資格, 請先收確認信, 並點選信裡的連結, 完成認證, 才能登入本網站");
            }

            // 將vm裡的密碼先雜湊之後,再與db裡的密碼比對
            var salt = HashUtility.GetSalt();
            var hashedPassword = HashUtility.ToSHA256(vm.Password, salt);

            if (string.Compare(developer.EncryptedPassword, hashedPassword, true) != 0)
            {
                throw new Exception("帳號或密碼有誤");
            }
        }

        private void ConfirmDeveloper(int developerId)
        {
            var db = new AppDbContext();
            var developer = db.Developers.Find(developerId); //一定能找到,所以不必防呆沒關係
            developer.IsConfirmed = true; // 視為已確認的會員
            developer.ConfirmCode = null; // 清空 confirm code 欄位

            db.SaveChanges();
        }

        private Developer developer(int developerId, string confirmCode)
        {
            return new AppDbContext().Developers.FirstOrDefault(d => d.Id == developerId && d.IsConfirmed == false && d.ConfirmCode == confirmCode);
        }


        
        

    }
}

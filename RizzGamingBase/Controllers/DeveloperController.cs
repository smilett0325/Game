using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.Repositories.EFRepositories;
using RizzGamingBase.Models.Services;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RizzGamingBase.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly AppDbContext _dbContext;

        public DeveloperController()
        {
            _dbContext = new AppDbContext();
        }

        public ActionResult Index()
        {
            List<DeveloperIndexVm> data = GetAll();
            return View(data);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(DeveloperLoginVm loginvm)
        {
            bool developerExist = _dbContext.Developers.Any(
                d => d.Name == loginvm.Name &&
                     d.Account == loginvm.Account &&
                     d.Password == loginvm.Password &&
                     d.Mail == loginvm.Mail);

            if (developerExist)
            {
                FormsAuthentication.SetAuthCookie(loginvm.Name, false);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "帳號密碼錯誤");
            return View(loginvm);
        }

        public ActionResult Signup()
        {
       
            return View();
        }

        [HttpPost]
        public ActionResult Signup(DeveloperDto developerdto)
        {
            // 檢查 ModelState 是否有效
            if (ModelState.IsValid)
            {
                // 在這裡執行註冊邏輯，使用 developerdto 中的數據
                var repo = new DeveloperRepository(); // 替換成實際的 Repository 類型
                var service = new DeveloperService(repo);
                service.CreateDevelopers(developerdto); // 替換成實際的服務類型

                // 注冊成功後，導向到其他頁面（這裡可能是登入頁面或首頁等）
                return RedirectToAction("Index");
            }

            // 如果 ModelState 無效，表示有驗證錯誤，重新顯示註冊表單
            return View(developerdto);
        }



        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public List<DeveloperIndexVm> GetAll()
        {
            var repo = new DeveloperRepository();
            var service = new DeveloperService(repo);
            var dto = service.GetAllDevelopers();
            var data = new List<DeveloperIndexVm>();

            foreach (var item in dto)
            {
                var model = new DeveloperIndexVm
                {
                    Id = item.Id,
                    Name = item.Name,
                    Account = item.Account,
                    Password = item.Password,
                    Mail = item.Mail,
                    Number = item.Number
                };
                data.Add(model);
            }

            return data;
        }
    }

}

using RizzGameingBase.Models.Repositories.EFRepositories;
using RizzGameingBase.Models.Services;
using RizzGameingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RizzGameingBase.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members  
        //實作網頁的地方
        public ActionResult Index()
        {
            List<MemberIndexVm> data = GetAll();
            return View(data);
        }

        public ActionResult Edit()
        {
            //要在新增一個 VIEWMODEL  
            //
            List<MemberIndexVm> data = GetAll();
            return View(data);
        }

        private List<MemberIndexVm> GetAll()
        {
            var repo = new MemberEFRepository();
            var servicer = new MemberService(repo);
            var dto = servicer.GetAllMembers();
            var data = new List<MemberIndexVm>();
            foreach (var item in dto)
            {
                var modle = new MemberIndexVm
                {
                    Id = item.Id,
                    Account = item.Account,
                    Password = item.Password,
                    Mail = item.Mail,
                    AvatarURL = item.AvatarURL,
                    Birthday = item.Birthday,
                    NickName=item.NickName,
                    RegistrationDate = item.RegistrationDate,
                    BanTime = item.BanTime,
                    LastLoginDate = item.LastLoginDate,

                };
                data.Add(modle);
            }
            return data;
        }
    }
}
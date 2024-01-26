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
            
            return View();
        }

        //撈一筆ID的資料
        public ActionResult Details(int id)
        {
            var getId = GetById(id);
            return View(getId);
        }


        //view model 記得要創一個轉型的
        //  MemberIndexVm  (要自己創一個新的 dto 轉成 VM)
        private MemberIndexVm GetById(int id) //找到編輯欄位
        {
            var repo = new MemberEFRepository();
            var servicer = new MemberService(repo);
            var dto = servicer.GetMemberById(id);
            var data = new MemberIndexVm
            {
                Id = dto.Id,
                Account=dto.Account,
                Password=dto.Password,
                Mail=dto.Mail,
                AvatarURL=dto.AvatarURL,
                BanTime=dto.BanTime,
                Birthday=dto.Birthday,
                NickName=dto.NickName,
                RegistrationDate=dto.RegistrationDate,
                LastLoginDate=dto.LastLoginDate,
               
                
            };
            return data;

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
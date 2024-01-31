using RizzGameingBase.Models.EFModels;
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
    public class AdminsController : Controller
    {
        // GET: Admins
        public ActionResult Index()
        {  
            List<AdminIndexVm> data = GetAll();
            return View(data);
        }

        private List<AdminIndexVm> GetAll()
        {
            var repo = new AdminEFRepository();
            var servicer = new AdminService(repo);
            var dto = servicer.GetAllAdmins();
            var data = new List<AdminIndexVm>();
            foreach (var item in dto)
            {
                var modle = new AdminIndexVm
                {
                    Id = item.Id,
                    Account = item.Account,
                    Password = item.Password,
                    CinfrimPassword = item.CinfrimPassword,
                    NickName = item.NickName,
                    AvatarURL = item.AvatarURL,
                    Position = item.Position,
                    PermissionId = item.PermissionId,
                    Permission = item.Permission,
                    PositionId = item.PositionId,


                };
                data.Add(modle);
            }
            return data;    
        }
        public ActionResult Delete(int id)
        {
            DeleteAdmin(id);
            return RedirectToAction("Index");
        }

        private void DeleteAdmin(int id)
        {
            //直接叫用ER。或叫用 Services OBJ
            var repo = new AdminEFRepository();
            var servicer = new AdminService(repo);
            var entity = db.BonusProducts.Find(id);
           
        }

    }
}
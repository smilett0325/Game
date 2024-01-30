using RizzGamingBase.Models.Dtos;
using RizzGamingBase.Models.EFModels;
using RizzGamingBase.Models.Entities;
using RizzGamingBase.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Exts
{
    public static class DeveloperExt
    {
        public static Developer EntityToEF(this DeveloperEntity model)
        {
            return new Developer
            {
                Id = model.Id,
                Name = model.Name,
                Account = model.Account,
                Password = model.Password,
                Mail= model.Mail,
                Number= model.Number
            };
        }

        public static DeveloperSignupVm ToDeveloperVm(this DeveloperDto model)
        {
            return new DeveloperSignupVm
            {
                Id = model.Id,
                Name = model.Name,
                Account = model.Account,
                Password = model.Password,
                Mail = model.Mail,


            };
        }
    }
}
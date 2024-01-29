using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
{
    public class BonusProductsIndexVm
    {
        public int Id { get; set; }

        [Display(Name = "類型ID")]
        public int ProductTypeid { get; set; }

        [Display(Name = "類型名稱")]
        public string TypeName { get; set; }

        [Display(Name = "價格")]
        public int Price { get; set; }

        [Display(Name = "檔案縮圖")]
        public string URL { get; set; }

        [Display(Name = "名稱")]
        public string Name { get; set; }
    }
}
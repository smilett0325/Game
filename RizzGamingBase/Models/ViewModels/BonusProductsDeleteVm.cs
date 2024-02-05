using RizzGamingBase.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
{
    public class BonusProductsDeleteVm
    {
        public int Id { get; set; }

        [Display(Name = "類型")]
        public int ProductTypeId { get; set; }

        public string ProductTypeName { get; set; }

        [Display(Name = "價格")]
        public int Price { get; set; }

        [Display(Name = "顯示檔案")]
        public string URL { get; set; }

        [Display(Name = "名稱")]
        public string Name { get; set; }

        public List<BonusProductType> ProductTypes;
    }
}
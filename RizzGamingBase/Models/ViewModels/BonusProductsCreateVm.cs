using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
{
    public class BonusProductsCreateVm
    {
        public int Id { get; set; }

        public int ProductTypeid { get; set; }

        [Display(Name = "類型名稱")]
        public string TypeName { get; set; }

        [Display(Name = "價格")]
        [Required(ErrorMessage = "{0}為必填項目")]
        public int Price { get; set; }

        [Display(Name = "上傳檔案")]
        [Required(ErrorMessage = "{0}為必填項目")]
        public string URL { get; set; }

        [Display(Name = "名稱")]
        [Required(ErrorMessage = "{0}為必填項目")]
        public string Name { get; set; }
    }
}
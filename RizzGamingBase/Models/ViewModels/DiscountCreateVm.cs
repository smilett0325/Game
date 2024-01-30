using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
{
    public class DiscountCreateVm
    {
        public int Id { get; set; }
        [Display(Name = "活動名稱")]
        public string DiscountName { get; set; }
        [Display(Name = "活動類型")]
        public string DiscountType { get; set; }
        [Display(Name = "活動圖片")]
        public string DiscountImage { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Percent { get; set; }
        public string Description { get; set; }

        [Display(Name = "遊戲")]
        public IEnumerable<DiscountItemInfo> Game { get; set; }
    }
}
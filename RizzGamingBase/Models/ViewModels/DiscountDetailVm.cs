using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
{
    public class DiscountDetailVm
    {
        [Display(Name = "活動名稱")]
        public string DiscountName { get; set; }

        [Display(Name = "活動類型")]
        public string DiscountType { get; set; }

        [Display(Name = "活動圖片")]
        public string DiscountImage { get; set; }

        [Display(Name = "開始日期")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Display(Name = "結束日期")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [Display(Name = "描述")]
        public string Description { get; set; }

        public IEnumerable<DiscountGameInfo> Game { get; set; }
    }

    public class DiscountGameInfo
    {
        public int Id { get; set; }
        public string Iamge { get; set; }
        public string Name { get; set; }
        public int Percent { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice =>Price - Price * Percent / 100;
    }
}
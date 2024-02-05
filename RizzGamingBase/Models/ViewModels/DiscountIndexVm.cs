using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
{
    public class DiscountIndexVm
    {
        public int Id { get; set; }
        [Display(Name = "活動名稱")]
        public string Name { get; set; }
        [Display(Name = "活動類型")]
        public string Type { get; set; }
        [Display(Name = "活動圖片")]
        public string Image { get; set; }
        [Display(Name = "開始時間")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Display(Name = "結束時間")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [Display(Name = "折扣百分比")]
        public int Percent { get; set; }
        [Display(Name = "活動描述")]
        public string Desciption { get; set; }
    }
}
using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
{
    public class DiscountVm
    {
        public int Id { get; set; }
        [Display(Name = "活動名稱")]
        public string DiscountName { get; set; }
        public string DiscountType { get; set; }
        [Display(Name = "活動圖片")]
        public string DiscountImage { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Percent { get; set; }
        public string Description { get; set; }
        public List<DiscountItemVm> DiscountItem { get; set; }

        public DiscountVm()
        {
            DiscountItem = new List<DiscountItemVm>(); // 初始化為空的集合
        }
    }

    public class DiscountItemVm
    {
        public int Id { get; set; }
        public int DiscountId {  get; set; }
        public int GameId { get; set; }
        public DiscountGameVm Game {  get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
{
    public class DiscountGameVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? MaxPercent { get; set; }
        public string Image {  get; set; }
        public string Developer {  get; set; }
    }
}
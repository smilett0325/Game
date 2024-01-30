using RizzGamingBase.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Entities
{
    public class DiscountEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Image {  get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Percent { get; set; }
        public string Desciption { get; set; }
        public IEnumerable<DiscountItemInfo> DiscountItem { get; set; }
    }

    public class DiscountItemInfo
    {
        public int Id { get; set; }
        public int DiscountId { get; set; }
        public int GameID { get; set; }
        public GameInfo Game { get; set; }
    }

    public class GameInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public decimal Price { get; set; }
        public int? MaxPercent { get; set; }
        public string Image { get; set; } 
    }
}
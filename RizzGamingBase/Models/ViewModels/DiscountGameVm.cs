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



        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // 這裡使用 Id 來判斷是否相同，你也可以加入其他屬性的比較邏輯
            return Id == ((DiscountGameVm)obj).Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
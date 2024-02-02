using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Dtos
{
    public class BonusProductsDto
    {
        public int Id { get; set; }

        public int ProductTypeid { get; set; }

        public string TypeName { get; set; }

        public int Price { get; set; }

        public string URL { get; set; }
        public string Name { get; set; }
    }
}
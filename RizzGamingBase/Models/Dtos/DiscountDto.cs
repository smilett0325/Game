using RizzGamingBase.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Dtos
{
    public class DiscountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public int Percent { get; set; }
        public string Desciption { get; set; }
        public IEnumerable<DiscountItemInfo> DiscountItem { get; set; }
        public string Developer { get; set; }
    }
	}

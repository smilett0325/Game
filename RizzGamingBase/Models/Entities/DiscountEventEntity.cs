using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Entities
{
	public class DiscountEventEntity
	{
		public int Id { get; set; }
		public string DiscountName { get; set; }
		public string DiscountImage { get; set; }
		public string DiscountType { get; set; }
		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }
		public int Percent { get; set; }
		public string Desciption { get; set; }
	}
}
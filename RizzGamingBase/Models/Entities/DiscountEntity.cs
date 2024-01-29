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

		public string Game { get; set; }
		public string GameTag { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public int Persent { get; set; }

		public string DiscountType { get; set; }

		public int Price { get; set; }

		public string Developer { get; set; }
	}
}
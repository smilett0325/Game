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
		[Display(Name = "遊戲名稱")]
		public string Game { get; set; }
		[Display(Name = "遊戲類別")]
		public string GameTag { get; set; }
		[Display(Name = "開發商")]
		public string Developer { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public int Persent { get; set; }

		public string DiscountType { get; set; }
		[Display(Name = "原價")]
		public int Price { get; set; }
		[Display(Name = "折扣後價錢")]
		public decimal DiscountPrice => (int)Math.Ceiling((double)Price * ((double)Persent / 100));
	}
}
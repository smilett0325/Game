using RizzGamingBase.Models.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Dtos
{
	public class DiscountItemDto
	{
		public int Id { get; set; }
		[Display(Name = "活動名稱")]
		public string DiscountName { get; set; }
		[Display(Name = "活動圖片")]
		public string DiscountImage { get; set; }
		[Display(Name = "遊戲")]
		public List<GameInfo> Game { get; set; }
		[Display(Name = "遊戲類別")]

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public int Persent { get; set; }
		public string Description { get; set; }
	}
}
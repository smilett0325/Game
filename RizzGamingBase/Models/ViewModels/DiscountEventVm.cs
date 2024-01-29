using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
{
	public class DiscountEventVm
	{
		public int Id { get; set; }
		[Display(Name = "活動名稱")]
		public string DiscountName { get; set; }
		[Display(Name = "活動圖片")]
		public string DiscountImage { get; set; }

		[Display(Name = "活動開始日期")]
		public DateTime StartDate { get; set; }
		[Display(Name = "活動結束日期")]
		public DateTime EndDate { get; set; }
		[Display(Name = "折扣%數")]
		public int Persent { get; set; }
		[Display(Name = "活動名稱")]
		public string DiscountType { get; set; }
		public string Desciption { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RizzGameBase.Models.EFModels;

namespace RizzGameBase.Models.ViewModels
{
	public class DeveloperGameEditVm
	{
		public int Id { get; set; }

		[Display(Name = "名稱")]
		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Display(Name = "簡介")]
		[Required]
		[StringLength(50)]
		public string Introduction { get; set; }

		[Display(Name = "說明")]
		[Required]
		[StringLength(1000)]
		public string Description { get; set; }

		[Display(Name = "發行日期")]
		[Column(TypeName = "date")]
		public DateTime ReleaseDate { get; set; }

		[Display(Name = "價格")]
		public int Price { get; set; }

		[Display(Name = "封面圖")]
		[Required]
		[StringLength(200)]
		public string Image { get; set; }

		[Display(Name = "輪播圖影")]
		[Required]
		[StringLength(200)]
		public string DisplayUrl { get; set; }

		[Display(Name = "標籤")]
		public List<Tag> Tags { get; set; }

		[Display(Name = "DLC")]
		public List<DLC> DLCs { get; set; }

		[Display(Name = "最低折扣")]
		public int? MaxPersent { get; set; }



		//	public int? DiscountId { get; set; }

		//	[Display(Name = "折扣")]
		//	public int? MaxPersent { get; set; }
	}
}
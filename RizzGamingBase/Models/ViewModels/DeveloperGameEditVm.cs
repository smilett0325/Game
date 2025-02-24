﻿using RizzGamingBase.Models.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
{
	public class DeveloperGameEditVm
	{
		public int Id { get; set; }
		public int DeveloperId { get; set; }

		[Display(Name = "遊戲名稱")]
		[Required(ErrorMessage = "請輸入遊戲名稱")]
		[StringLength(50)]
		public string Name { get; set; }

		[Display(Name = "遊戲簡介")]
		[Required(ErrorMessage = "請輸入遊戲簡介")]
		[StringLength(50)]
		public string Introduction { get; set; }

		[Display(Name = "遊戲說明")]
		[Required(ErrorMessage = "請輸入遊戲說明")]
		[StringLength(1000)]
		public string Description { get; set; }

		[Display(Name = "發行日期")]
		[Required(ErrorMessage = "請輸入發行日期")]
		[DataType(DataType.DateTime)]
		public DateTime ReleaseDate { get; set; }

		[Display(Name = "價格")]
		public int Price { get; set; }

		[Display(Name = "封面圖")]
		[StringLength(200)]
		public string Cover { get; set; }

		[Display(Name = "最低折扣")]
		public int? MaxPercent { get; set; }

		[Display(Name = "輪播圖")]
		public List<string> DisplayImages { get; set; }


		//[Display(Name = "特價活動")]
		//[Required]
		//[StringLength(200)]
		//public List<DiscountDto> Discounts { get; set; }

		[Display(Name = "標籤")]
		public List<TagDto> Tags { get; set; }

		[Display(Name = "DLC")]
		public List<GameDto> DLCs { get; set; }

		[Display(Name = "預告片")]
		//[Required]
		[StringLength(200)]
		public string Video { get; set; }



		//	public int? DiscountId { get; set; }

		//	[Display(Name = "折扣")]
		//	public int? MaxPercent { get; set; }
	}
}
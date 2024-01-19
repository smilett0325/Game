using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGameBase.Models.Entities
{
	public class GameEntity
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[StringLength(50)]
		public string Introduction { get; set; }

		[Required]
		[StringLength(1000)]
		public string Description { get; set; }

		[Column(TypeName = "date")]
		public DateTime ReleaseDate { get; set; }

		public int Price { get; set; }

		[Required]
		[StringLength(200)]
		public string Image { get; set; }

		public int DeveloperId { get; set; }

		public int GameTagId { get; set; }

		public int? DiscountId { get; set; }

		public int? MaxPersent { get; set; }

		//public int? SeasonDiscountId { get; set; }
		//public int? CustomerDiscountId { get; set; }
	}
}
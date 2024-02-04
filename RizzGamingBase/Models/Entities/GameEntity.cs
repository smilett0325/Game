using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Entities
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
		public string Cover { get; set; }

		public int DeveloperId { get; set; }

		public int? MaxPercent { get; set; }

		[Required]
		[StringLength(200)]
		public string Video { get; set; }

		//public int? SeasonDiscountId { get; set; }
		//public int? CustomerDiscountId { get; set; }
	}
}
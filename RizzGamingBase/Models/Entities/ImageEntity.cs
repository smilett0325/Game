using RizzGamingBase.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Entities
{
	public class ImageEntity
	{
		public int Id { get; set; }

		public int GameId { get; set; }

		[Required]
		[StringLength(3000)]
		public string DisplayImage { get; set; }

		public virtual Game Game { get; set; }
	}
}
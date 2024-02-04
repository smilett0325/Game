using RizzGamingBase.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Entities
{
	public class GTEntity
	{
		public int Id { get; set; }

		[Required]
		public int GameId { get; set; }

		[Required]
		public int TagId { get; set; }

		public virtual Game Game { get; set; }

		public virtual Tag Tag { get; set; }
	}
}
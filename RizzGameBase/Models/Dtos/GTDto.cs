using RizzGameBase.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGameBase.Models.Dtos
{
	public class GTDto
	{
		public int Id { get; set; }
	
		public int GameId { get; set; }

		public int TagId { get; set; }

		public virtual Game Game { get; set; }

		public virtual Tag Tag { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Dtos
{
	public class GameDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Introduction { get; set; }

		public string Description { get; set; }

		public DateTime ReleaseDate { get; set; }

		public int Price { get; set; }

		public string Cover { get; set; }

		public int DeveloperId { get; set; }

		public int? MaxPercent { get; set; }

		public string Video { get; set; }
	}
}
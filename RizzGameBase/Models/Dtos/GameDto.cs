using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGameBase.Models.Dtos
{
	public class GameDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Introduction { get; set; }

		public string Description { get; set; }

		public DateTime ReleaseDate { get; set; }

		public int Price { get; set; }

		public string Image { get; set; }

		public int DeveloperId { get; set; }

		public int? MaxPersent { get; set; }
	}
}
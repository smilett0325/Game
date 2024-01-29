using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Entities
{
	public class TagEntity
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Dtos
{
	public class GameDataDto
	{
		public int Id { get; set; }
		public string GameName { get; set; }
		public string DeveloperName { get; set; }
		public DateTime TransactionDate { get; set; }
		public decimal Price { get; set; }
	}
}
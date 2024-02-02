using RizzGamingBase.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Entity
{
	public class GameDataEntity : ISelectListItem
	{
		public int Id { get; set; }
		public string GameName { get; set; }

		public string DeveloperName { get; set; }
		public DateTime TransactionDate { get; set; }
		public decimal Amount { get; set; }

	}
}
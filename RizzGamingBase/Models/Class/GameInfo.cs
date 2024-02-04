using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Class
{
	public class GameInfo
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public int Price { get; set; }
		public string Developer { get; set; }
		public string GameImage { get; set; }
		public string GameTag { get; set; }
		public int? MaxPercent { get; set; }
	}
}
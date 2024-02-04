using RizzGamingBase.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Dtos
{
	public class DLCDto
	{
		public int Id { get; set; }

		public int GameId { get; set; }

		public int AttachmentGameId { get; set; }

		public virtual Game Game { get; set; }

		public virtual Game Game1 { get; set; }
	}
}
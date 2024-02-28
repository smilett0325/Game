using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Dtos
{
	public class BanMemberDto
	{
		public int Id { get; set; }

		public int Member1Id { get; set; }

		public int Member2Id { get; set; }

		public int? BoardId { get; set; }

		public int? MessageId { get; set; }

		public int? CommentId { get; set; }

		public string Content { get; set; }

		public int? AdminId { get; set; }

		public DateTime? StatusTime { get; set; }

		public bool? Status { get; set; }
	}
}
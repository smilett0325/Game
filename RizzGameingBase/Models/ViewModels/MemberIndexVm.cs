using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGameingBase.Models.ViewModels
{
	public class MemberIndexVm
	{
		//網頁需要的 
		[Required]
		[StringLength(50)]
		public string Account { get; set; }

		[Required]
		[StringLength(50)]
		public string Password { get; set; }

		[Required]
		[StringLength(50)]
		public string Mail { get; set; }

		public DateTime? RegistrationDate { get; set; }
	}
}
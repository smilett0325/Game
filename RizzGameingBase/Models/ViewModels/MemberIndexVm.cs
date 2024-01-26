using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGameingBase.Models.ViewModels
{
	public class MemberIndexVm
	{
        //網頁需要的 //設驗證

        public int Id { get; set; }
        

        [Required]
		[StringLength(50)]
		public string Account { get; set; }

		[Required]
		[StringLength(50)]
		public string Password { get; set; }
        public string AvatarURL { get; set; }
        public string NickName { get; set; }


        public DateTime? Birthday { get; set; }

        [Required]
		[StringLength(50)]
		public string Mail { get; set; }

        public DateTime? BanTime { get; set; }

        public int? Bonus { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime? LastLoginDate { get; set; }
    }
}
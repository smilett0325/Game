using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
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

        [Required]
        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(200)]
        public string AvatarURL { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime? BanTime { get; set; }

        public int? Bonus { get; set; }

        public DateTime? LastLoginDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        [Required]
        [StringLength(50)]
        public string NickName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.Dtos
{
    public class MemberDto
    {
        //憑證這裡都刪除  放在VM裡面
        public int Id { get; set; }

        
        
        public string Account { get; set; }

        
        public string Password { get; set; }

        
        public string Mail { get; set; }

        
        public string AvatarURL { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime? BanTime { get; set; }

        public int? Bonus { get; set; }

        public DateTime? LastLoginDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        
        public string NickName { get; set; }
    }
}
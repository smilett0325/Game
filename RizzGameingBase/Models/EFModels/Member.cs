namespace RizzGameingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Member
    {
        // EFModel ���A�ظm�n��Class  ,  ���ΰʨ� ���D��Ʈw���ק�,�b���s�ظm�@�ӷs��EFMODEL 
        // �O�oef �o�M�󤤤�n�R�����b���s�ظm�@���Y�i
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

        public DateTime? Birthday { get; set; }

        [StringLength(50)]
        public string NickName { get; set; }
    }
}

namespace RizzGameingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Member
    {
        // EFModel 幫你建置好的Class  ,  不用動到 除非資料庫有修改,在重新建置一個新的EFMODEL 
        // 記得ef 得套件中文要刪除掉在重新建置一次即可
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

using RizzGameingBase.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
{
    public class AdminIndexVm
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string CinfrimPassword { get; set; }

        [Required]
        [StringLength(50)]
        public string NickName { get; set; }

        [StringLength(200)]
        public string AvatarURL { get; set; }

        public int? PositionId { get; set; }

        public int? PermissionId { get; set; }

        public virtual Permission Permission { get; set; }

        public virtual Position Position { get; set; }
    }
}
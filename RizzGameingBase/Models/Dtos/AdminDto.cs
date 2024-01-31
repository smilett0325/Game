using RizzGameingBase.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGameingBase.Models.Dtos
{
    public class AdminDto
    {
        public int Id { get; set; }

        
        public string Account { get; set; }

        
        public string Password { get; set; }

        
        public string CinfrimPassword { get; set; }

        
        public string NickName { get; set; }

       
        public string AvatarURL { get; set; }

        public int? PositionId { get; set; }

        public int? PermissionId { get; set; }

        public virtual Permission Permission { get; set; }

        public virtual Position Position { get; set; }
    }

}
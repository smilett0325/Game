using RizzGamingBase.Models.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels.Developer
{
    public class ForgetPasswordVm
    {
        [Display(Name = "帳號")]
        [Required(ErrorMessage = DAHelper.Required)]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "帳號長度應該在6-12位之間")]
        public string Account { get; set; }

        [Display(Name = "EMail")]
        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string EMail { get; set; }
    }
}
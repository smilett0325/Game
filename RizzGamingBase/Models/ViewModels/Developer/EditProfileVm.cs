using RizzGamingBase.Models.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
{
    public class EditProfileVm
    {

        public int Id { get; set; }

        [Display(Name = "姓名")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "EMail")]
        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string EMail { get; set; }



        [Display(Name = "電話號碼")]
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
    }
}
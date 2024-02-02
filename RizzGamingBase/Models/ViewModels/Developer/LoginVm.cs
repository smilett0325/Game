using RizzGamingBase.Models.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
{
    public class LoginVm
    {


        [Display(Name = "帳號")]
        [Required(ErrorMessage = DAHelper.Required)]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "帳號長度應該在6-12位之間")]
        public string Account { get; set; }



        [Display(Name = "密碼")]
        [Required(ErrorMessage = DAHelper.Required)] // 設置必填錯誤訊息
        [StringLength(12, MinimumLength = 6, ErrorMessage = "密碼長度應該在6-12位之間")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

}

using RizzGamingBase.Models.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RizzGamingBase.Models.ViewModels
{
    public class RegisterVm
    {

        public int Id { get; set; }

        [Display(Name = "姓名")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "帳號")]
        [Required(ErrorMessage = DAHelper.Required)]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "帳號長度應該在6-12位之間")]
        public string Account { get; set; }

        /// <summary>
        /// 明碼
        /// </summary>
        [Display(Name = "密碼")]
        [Required(ErrorMessage = DAHelper.Required)] // 設置必填錯誤訊息
        [StringLength(12, MinimumLength = 6, ErrorMessage = "密碼長度應該在6-12位之間")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

      
        [Display(Name = "確認密碼")]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

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
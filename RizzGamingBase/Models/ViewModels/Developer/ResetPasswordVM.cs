using RizzGamingBase.Models.Infra;
using System.ComponentModel.DataAnnotations;

namespace RizzGamingBase.Models.ViewModels.Developer
{
    public class ResetPasswordVM
    {
        [Display(Name = "原始密碼")]
        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string OriginalPassword { get; set; }

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

       
}
}
namespace RizzGamingBase.Models.EFModels
{
    using RizzGamingBase.Models.Infra;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Developer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Developer()
        {
            Games = new HashSet<Game>();
        }

        [Required(ErrorMessage = DAHelper.Required)]
        public int Id { get; set; }

        [Display(Name = "開發商名稱")]
        [Required(ErrorMessage = DAHelper.Required)]
        [StringLength(30, ErrorMessage = DAHelper.StringLength)]
        public string Name { get; set; }

        [Display(Name = "帳號")]
        [Required(ErrorMessage = DAHelper.Required)]
        [StringLength(200, ErrorMessage = DAHelper.StringLength)]
        public string Account { get; set; }

        [Display(Name = "密碼")]
        [Required(ErrorMessage = DAHelper.Required)] // 設置必填錯誤訊息
        [StringLength(30, ErrorMessage = DAHelper.StringLength2)] // 設置長度不合法的錯誤訊息
        public string Password { get; set; }

        [Display(Name = "信箱")]
        [Required(ErrorMessage = DAHelper.EmailAddress)]
        [StringLength(30, ErrorMessage = DAHelper.StringLength)]
        public string Mail { get; set; }


        [Display(Name = "電話號碼")]
        [StringLength(10, ErrorMessage = "電話號碼長度不能超過10個字")]
        public string Number { get; set; }

        public DateTime? BanTime { get; set; }

        public bool? IsBaned { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Game> Games { get; set; }
    }
}

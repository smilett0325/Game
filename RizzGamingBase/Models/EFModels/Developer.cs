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

        [Display(Name = "�}�o�ӦW��")]
        [Required(ErrorMessage = DAHelper.Required)]
        [StringLength(30, ErrorMessage = DAHelper.StringLength)]
        public string Name { get; set; }

        [Display(Name = "�b��")]
        [Required(ErrorMessage = DAHelper.Required)]
        [StringLength(200, ErrorMessage = DAHelper.StringLength)]
        public string Account { get; set; }

        [Display(Name = "�K�X")]
        [Required(ErrorMessage = DAHelper.Required)] // �]�m������~�T��
        [StringLength(30, ErrorMessage = DAHelper.StringLength2)] // �]�m���פ��X�k�����~�T��
        public string Password { get; set; }

        [Display(Name = "�H�c")]
        [Required(ErrorMessage = DAHelper.EmailAddress)]
        [StringLength(30, ErrorMessage = DAHelper.StringLength)]
        public string Mail { get; set; }


        [Display(Name = "�q�ܸ��X")]
        [StringLength(10, ErrorMessage = "�q�ܸ��X���פ���W�L10�Ӧr")]
        public string Number { get; set; }

        public DateTime? BanTime { get; set; }

        public bool? IsBaned { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Game> Games { get; set; }
    }
}

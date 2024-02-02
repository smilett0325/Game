namespace RizzGamingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BounsProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BounsProduct()
        {
            BounsBillDetails = new HashSet<BounsBillDetail>();
            BounsItems = new HashSet<BounsItem>();
        }

        public int Id { get; set; }

        public int ProductTypeId { get; set; }

        public int Price { get; set; }

        [Required]
        [StringLength(3000)]
        public string URL { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BounsBillDetail> BounsBillDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BounsItem> BounsItems { get; set; }

        public virtual BounsProductType BounsProductType { get; set; }
    }
}

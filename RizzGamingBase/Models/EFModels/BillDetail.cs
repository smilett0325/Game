namespace RizzGamingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BillDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BillDetail()
        {
            Collections = new HashSet<Collection>();
        }

        public int Id { get; set; }

        public int GameId { get; set; }

        public int MemberId { get; set; }

        public decimal FinalPayment { get; set; }

        public int BounsPoint { get; set; }

        public DateTime TransactionDate { get; set; }

        public int? DiscountId { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual Game Game { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Collection> Collections { get; set; }
    }
}

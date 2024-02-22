namespace RizzGamingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {
            BanMembers = new HashSet<BanMember>();
        }

        public int Id { get; set; }

        public int MemberId { get; set; }

        public int GameId { get; set; }

        public int Rating { get; set; }

        [Column("Comment")]
        [Required]
        [StringLength(1000)]
        public string Comment1 { get; set; }

        public DateTime Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BanMember> BanMembers { get; set; }

        public virtual Game Game { get; set; }

        public virtual Member Member { get; set; }
    }
}

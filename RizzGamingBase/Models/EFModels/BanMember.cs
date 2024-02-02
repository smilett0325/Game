namespace RizzGamingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BanMember
    {
        public int Id { get; set; }

        public int Member1Id { get; set; }

        public int Member2Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Content { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int? AdminId { get; set; }

        public DateTime? StatusTime { get; set; }

        public bool? Status { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual Member Member { get; set; }

        public virtual Member Member1 { get; set; }
    }
}

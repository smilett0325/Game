namespace RizzGamingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Friend
    {
        public int Id { get; set; }

        public int Member1Id { get; set; }

        public int Member2Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Relationship { get; set; }

        public virtual Member Member { get; set; }

        public virtual Member Member1 { get; set; }
    }
}

namespace RizzGamingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Picture
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Image { get; set; }

        public int MemberId { get; set; }

        public int BoardId { get; set; }

        public int MessageId { get; set; }

        public virtual Board Board { get; set; }

        public virtual Member Member { get; set; }

        public virtual Message Message { get; set; }
    }
}

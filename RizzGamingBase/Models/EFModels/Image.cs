namespace RizzGamingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        [Required]
        [StringLength(3000)]
        public string Display { get; set; }

        public virtual Game Game { get; set; }
    }
}

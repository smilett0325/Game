namespace RizzGameBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Video
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        [Required]
        [StringLength(3000)]
        public string DisplayVideo { get; set; }

        public virtual Game Game { get; set; }
    }
}

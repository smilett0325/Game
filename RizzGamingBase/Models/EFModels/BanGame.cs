namespace RizzGamingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BanGame
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int GameId { get; set; }

        [Required]
        [StringLength(200)]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public int AdminId { get; set; }

        public DateTime? StatusTime { get; set; }

        public bool? Status { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual Game Game { get; set; }

        public virtual Member Member { get; set; }
    }
}

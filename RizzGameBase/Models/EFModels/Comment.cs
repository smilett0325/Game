namespace RizzGameBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int GameId { get; set; }

        public int Rating { get; set; }

        [Column("Comment")]
        public int Comment1 { get; set; }

        public DateTime Date { get; set; }

        public virtual Game Game { get; set; }

        public virtual Member Member { get; set; }
    }
}

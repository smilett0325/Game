namespace RizzGameBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GameTag
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public int TagId { get; set; }

        public virtual Game Game { get; set; }

        public virtual Tag Tag { get; set; }
    }
}

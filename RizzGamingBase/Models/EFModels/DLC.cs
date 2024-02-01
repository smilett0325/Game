namespace RizzGamingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DLC
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public int AttachedGameId { get; set; }

        public virtual Game Game { get; set; }

        public virtual Game Game1 { get; set; }
    }
}

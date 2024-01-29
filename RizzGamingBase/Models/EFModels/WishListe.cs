namespace RizzGamingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WishListe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int GameId { get; set; }

        public int DiscountId { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual Game Game { get; set; }

        public virtual Member Member { get; set; }
    }
}

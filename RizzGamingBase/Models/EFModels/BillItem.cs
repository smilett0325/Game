namespace RizzGamingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BillItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int BillDetailId { get; set; }

        public int GameId { get; set; }

        public decimal Price { get; set; }

        public virtual BillDetail BillDetail { get; set; }

        public virtual Game Game { get; set; }
    }
}

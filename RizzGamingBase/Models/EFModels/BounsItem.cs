namespace RizzGamingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BounsItem
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int ProductId { get; set; }

        public virtual Member Member { get; set; }

        public virtual BounsProduct BounsProduct { get; set; }
    }
}

namespace RizzGamingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BounsBillDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int BounsId { get; set; }

        public int MemberId { get; set; }

        public DateTime TransctionDate { get; set; }

        public virtual BounsProduct BounsProduct { get; set; }

        public virtual Member Member { get; set; }
    }
}

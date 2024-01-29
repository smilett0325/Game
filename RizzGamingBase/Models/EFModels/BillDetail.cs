namespace RizzGamingBase.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BillDetail
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public int MemberId { get; set; }

        public decimal FinalPayment { get; set; }

        public int BounsPoint { get; set; }

        public DateTime TransactionDate { get; set; }

        public int? DiscountId { get; set; }
    }
}

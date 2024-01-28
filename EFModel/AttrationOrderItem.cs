namespace EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AttrationOrderItem
    {
        public int Id { get; set; }

        public int AttractionOrderId { get; set; }

        public int AttractionTicketId { get; set; }

        public int Qty { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual AttractionOrder AttractionOrder { get; set; }

        public virtual AttractionTicket AttractionTicket { get; set; }
    }
}

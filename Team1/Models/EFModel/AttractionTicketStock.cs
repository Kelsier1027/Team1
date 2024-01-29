namespace Team1.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AttractionTicketStock
    {
        public int Id { get; set; }

        public int AttractionTicketId { get; set; }

        public int stock { get; set; }

        public DateTime? ReserveDate { get; set; }

        public virtual AttractionTicket AttractionTicket { get; set; }
    }
}

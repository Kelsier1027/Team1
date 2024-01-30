namespace Team1.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AttractionTicket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AttractionTicket()
        {
            AttractionTicketStocks = new HashSet<AttractionTicketStock>();
            AttrationOrderItems = new HashSet<AttrationOrderItem>();
        }

        public int Id { get; set; }

        public int AttractionId { get; set; }

        public decimal Price { get; set; }

        public int Discount { get; set; }

        public int AttractionTicketTypeId { get; set; }

        public bool TicketStatus { get; set; }

        public virtual Attraction Attraction { get; set; }

        public virtual AttractionTicketType AttractionTicketType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttractionTicketStock> AttractionTicketStocks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttrationOrderItem> AttrationOrderItems { get; set; }
    }
}

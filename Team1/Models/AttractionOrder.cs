namespace Team1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AttractionOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AttractionOrder()
        {
            AttrationOrderItems = new HashSet<AttrationOrderItem>();
        }

        public int Id { get; set; }

        public int MemberId { get; set; }

        public DateTime? OrderDate { get; set; }

        public decimal Price { get; set; }

        public int AttractionOrderStatusId { get; set; }

        public virtual AttractionOrderStatus AttractionOrderStatus { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttrationOrderItem> AttrationOrderItems { get; set; }
    }
}

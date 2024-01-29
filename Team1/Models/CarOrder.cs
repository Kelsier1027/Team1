namespace Team1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CarOrder
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int CarId { get; set; }

        public int? AdminId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartDateTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndDateTime { get; set; }

        public int Price { get; set; }

        public int CarOrderStatusId { get; set; }

        public virtual BEAdmin BEAdmin { get; set; }

        public virtual CarOrderStatus CarOrderStatus { get; set; }

        public virtual Car Car { get; set; }

        public virtual Member Member { get; set; }
    }
}

namespace Team1.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HotelOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelOrder()
        {
            HotelOrderItems = new HashSet<HotelOrderItem>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderSn { get; set; }

        public int NumberOfPeople { get; set; }

        public bool Breakfast { get; set; }

        public int HotelOrderStatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string CreditCard { get; set; }

        public int MemberId { get; set; }

        public int Price { get; set; }

        public DateTime Checkin { get; set; }

        public DateTime Checkout { get; set; }

        public int? HotelOrderCancelReasonId { get; set; }

        public int AdminId { get; set; }

        public virtual BEAdmin BEAdmin { get; set; }

        public virtual HotelOrderCancelReason HotelOrderCancelReason { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelOrderItem> HotelOrderItems { get; set; }

        public virtual HotelOrderStatus HotelOrderStatus { get; set; }

        public virtual Member Member { get; set; }
    }
}

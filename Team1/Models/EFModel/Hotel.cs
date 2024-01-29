namespace Team1.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotel()
        {
            HotelImages = new HashSet<HotelImage>();
            HotelRooms = new HashSet<HotelRoom>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public int DistrictId { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        public decimal Grade { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        public int? Level { get; set; }

        [Required]
        public string MainImage { get; set; }

        public TimeSpan CheckinStart { get; set; }

        public TimeSpan? CheckinEnd { get; set; }

        public TimeSpan? CheckoutStart { get; set; }

        public TimeSpan CheckoutEnd { get; set; }

        public int? AddBedFee { get; set; }

        public int? BreakfastPrice { get; set; }

        public int HotelTypeId { get; set; }

        [Required]
        public string HotelFacilities { get; set; }

        public string Email { get; set; }

        public virtual District District { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelImage> HotelImages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelRoom> HotelRooms { get; set; }

        public virtual HotelType HotelType { get; set; }
    }
}

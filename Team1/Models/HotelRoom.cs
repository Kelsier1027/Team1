namespace Team1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HotelRoom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelRoom()
        {
            HotelOrderItems = new HashSet<HotelOrderItem>();
            HotelRoomImages = new HashSet<HotelRoomImage>();
            PackageHotelRoomItems = new HashSet<PackageHotelRoomItem>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int HotelId { get; set; }

        [Required]
        [StringLength(50)]
        public string Size { get; set; }

        [Required]
        public string RoomFacilities { get; set; }

        public int Capacity { get; set; }

        public int BedCapacity { get; set; }

        [Required]
        public string MainImage { get; set; }

        public int WeekdayPrice { get; set; }

        public int WeekendPrice { get; set; }

        public int AddTimeFee { get; set; }

        public int Count { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelOrderItem> HotelOrderItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelRoomImage> HotelRoomImages { get; set; }

        public virtual Hotel Hotel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackageHotelRoomItem> PackageHotelRoomItems { get; set; }
    }
}

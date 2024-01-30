namespace Team1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PackageHotelRoomItem
    {
        public int Id { get; set; }

        public int HotelRoomId { get; set; }

        public int PackageId { get; set; }

        public virtual HotelRoom HotelRoom { get; set; }

        public virtual Package Package { get; set; }
    }
}

namespace EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HotelOrderItem
    {
        public int Id { get; set; }

        public int HotelRoomId { get; set; }

        public int HotelOrderId { get; set; }

        public virtual HotelOrder HotelOrder { get; set; }

        public virtual HotelRoom HotelRoom { get; set; }
    }
}

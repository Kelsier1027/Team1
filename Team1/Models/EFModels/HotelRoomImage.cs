namespace Team1.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HotelRoomImage
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        public int HotelRoomId { get; set; }

        public virtual HotelRoom HotelRoom { get; set; }
    }
}

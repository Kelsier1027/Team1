namespace Team1.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HotelImage
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}

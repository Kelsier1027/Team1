namespace Team1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HotelCategory
    {
        public int Id { get; set; }

        [Required]
        public string JAON { get; set; }
    }
}

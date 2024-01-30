namespace EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AttractionContent
    {
        public int Id { get; set; }

        public int AttractionId { get; set; }

        [Required]
        public string Context { get; set; }

        public virtual Attraction Attraction { get; set; }
    }
}

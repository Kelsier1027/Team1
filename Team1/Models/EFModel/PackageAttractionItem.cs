namespace Team1.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PackageAttractionItem
    {
        public int Id { get; set; }

        public int AttractionId { get; set; }

        public int PackageId { get; set; }

        public virtual Attraction Attraction { get; set; }

        public virtual Package Package { get; set; }
    }
}

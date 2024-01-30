namespace Team1.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PackageMemos")]
    public partial class PackageMemo
    {
        public int Id { get; set; }

        public int Days { get; set; }

        [Required]
        public string DaysMemo { get; set; }

        [Required]
        [StringLength(200)]
        public string Breakfast { get; set; }

        [Required]
        [StringLength(200)]
        public string Lunch { get; set; }

        [Required]
        [StringLength(200)]
        public string Dinner { get; set; }

        public int PackageId { get; set; }

        public virtual Package Package { get; set; }
    }
}

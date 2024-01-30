namespace Team1.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QA
    {
        public int Id { get; set; }

        public int ServiceCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string QName { get; set; }

        [StringLength(500)]
        public string AnsText { get; set; }

        public virtual ServiceCategory ServiceCategory { get; set; }
    }
}

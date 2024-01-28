namespace EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PointTransction
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        [Required]
        [StringLength(20)]
        public string TransactionType { get; set; }

        [Required]
        [StringLength(30)]
        public string TransactionCategory { get; set; }

        [Required]
        [StringLength(30)]
        public string Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public virtual Member Member { get; set; }
    }
}

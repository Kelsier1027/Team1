namespace Team1.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommentImage
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }
    }
}

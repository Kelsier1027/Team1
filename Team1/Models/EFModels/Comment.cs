namespace Team1.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {
            CommentImages = new HashSet<CommentImage>();
        }

        public int Id { get; set; }

        public int MemberId { get; set; }

        public int Rating { get; set; }

        [StringLength(50)]
        public string Text { get; set; }

        public DateTime CommentDateTime { get; set; }

        public int ServiceCategoryId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommentImage> CommentImages { get; set; }

        public virtual Member Member { get; set; }

        public virtual ServiceCategory ServiceCategory { get; set; }
    }
}

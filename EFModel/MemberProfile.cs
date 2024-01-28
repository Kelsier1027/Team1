namespace EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberProfile
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        public int? GenderId { get; set; }

        public string ProfileImage { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual Member Member { get; set; }
    }
}

namespace Team1.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberPersonalInfos")]
    public partial class MemberPersonalInfo
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        [StringLength(10)]
        public string IDNumber { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(40)]
        public string EmCName { get; set; }

        [StringLength(10)]
        public string EmCPhone { get; set; }

        public virtual Member Member { get; set; }
    }
}

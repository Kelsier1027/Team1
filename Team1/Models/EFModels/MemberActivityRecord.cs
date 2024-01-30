namespace Team1.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberActivityRecord
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public DateTime ActivityTime { get; set; }

        public bool ActivityType { get; set; }

        public int? SessionDuration { get; set; }

        [StringLength(50)]
        public string IpAddress { get; set; }

        [MaxLength(50)]
        public byte[] Device { get; set; }

        public virtual Member Member { get; set; }
    }
}

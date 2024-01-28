namespace EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PackageOrde
    {
        public int Id { get; set; }

        public int PackageId { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PackageOrdeStatusId { get; set; }

        public int MemberId { get; set; }

        public virtual Member Member { get; set; }

        public virtual PackageOrderStatus PackageOrderStatus { get; set; }

        public virtual Package Package { get; set; }
    }
}

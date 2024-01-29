namespace Team1.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            AttractionOrders = new HashSet<AttractionOrder>();
            CarOrders = new HashSet<CarOrder>();
            Comments = new HashSet<Comment>();
            HotelOrders = new HashSet<HotelOrder>();
            MemberActivityRecords = new HashSet<MemberActivityRecord>();
            MemberPersonalInfos = new HashSet<MemberPersonalInfo>();
            MemberProfiles = new HashSet<MemberProfile>();
            PackageOrdes = new HashSet<PackageOrde>();
            PointTransctions = new HashSet<PointTransction>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Account { get; set; }

        [Required]
        public string EncryptedPassword { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool ActiveStatus { get; set; }

        [Required]
        public string Salt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttractionOrder> AttractionOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarOrder> CarOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelOrder> HotelOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberActivityRecord> MemberActivityRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberPersonalInfo> MemberPersonalInfos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberProfile> MemberProfiles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackageOrde> PackageOrdes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PointTransction> PointTransctions { get; set; }
    }
}

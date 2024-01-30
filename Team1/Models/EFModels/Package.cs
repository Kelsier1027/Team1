namespace Team1.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Package
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Package()
        {
            PackageAttractionItems = new HashSet<PackageAttractionItem>();
            PackageHotelRoomItems = new HashSet<PackageHotelRoomItem>();
            PackageMemos = new HashSet<PackageMemo>();
            PackageOrdes = new HashSet<PackageOrde>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Price { get; set; }

        public int LowestGo { get; set; }

        public DateTime ApplyEndDate { get; set; }

        public DateTime ApplyBeginDate { get; set; }

        public int CanSold { get; set; }

        public int TotalNum { get; set; }

        [Required]
        [StringLength(50)]
        public string Image { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Alert { get; set; }

        [Required]
        public string PriceDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackageAttractionItem> PackageAttractionItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackageHotelRoomItem> PackageHotelRoomItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackageMemo> PackageMemos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackageOrde> PackageOrdes { get; set; }
    }
}

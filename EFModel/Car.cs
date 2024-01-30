namespace EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            CarOrders = new HashSet<CarOrder>();
        }

        public int Id { get; set; }

        public int CarModelId { get; set; }

        [Required]
        [StringLength(50)]
        public string CarLicenceId { get; set; }

        public int Mileage { get; set; }

        public int CarStatusId { get; set; }

        public int DistrictId { get; set; }

        public virtual CarModel CarModel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarOrder> CarOrders { get; set; }

        public virtual CarStatus CarStatus { get; set; }

        public virtual District District { get; set; }
    }
}

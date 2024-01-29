namespace Team1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BEAdmin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BEAdmin()
        {
            AdminRoles = new HashSet<AdminRole>();
            CarOrders = new HashSet<CarOrder>();
            HotelOrders = new HashSet<HotelOrder>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Account { get; set; }

        [Required]
        public string EncryptedPassword { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool ActiveStatus { get; set; }

        [Required]
        public string Salt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdminRole> AdminRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarOrder> CarOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelOrder> HotelOrders { get; set; }
    }
}

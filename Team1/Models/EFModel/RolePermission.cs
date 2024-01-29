namespace Team1.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RolePermission
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        public virtual Permission Permission { get; set; }

        public virtual Role Role { get; set; }
    }
}

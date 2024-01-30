namespace Team1.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AdminRole
    {
        public int Id { get; set; }

        public int AdminId { get; set; }

        public int RoleId { get; set; }

        public virtual BEAdmin BEAdmin { get; set; }

        public virtual Role Role { get; set; }
    }
}

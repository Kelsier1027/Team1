using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team1.個人.Huang.Interfaces;

namespace Team1.個人.Huang.Entities
{
    public class ServiceCategoryEntity : ISelectListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
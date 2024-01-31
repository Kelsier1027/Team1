using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team1.個人.Huang.Entities
{
    public class QAsEntity
    {
        public int Id { get; set; }
        public string ServiceCategoryName { get; set; }
        public int ServiceCategoryId { get; set; }
        public string QName { get; set; }
        public string AnsText { get; set; }
    }
}
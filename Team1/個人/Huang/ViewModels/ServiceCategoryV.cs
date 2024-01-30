using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team1.個人.Huang.ViewModels
{
    public class ServiceCategoryVm
    {
        public int Id { get; set; }

        [Display(Name = "分類名稱")]
        public string Name { get; set; }
    }
}
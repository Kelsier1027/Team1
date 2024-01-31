using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team1.個人.Huang.ViewModels
{
    public class QAsVm
    {
        public int Id { get; set; }

        [Display(Name = "分類名稱")]
        public string ServiceCategoryName { get; set; }
        public int ServiceCategoryId { get; set; }
        [Display(Name = "問題")]
        public string QName { get; set; }
        [Display(Name = "答案")]
        public string AnsText { get; set; }
    }
}
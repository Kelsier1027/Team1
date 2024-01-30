using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team1.個人.Huang.ViewModels
{
    public class CommentVm
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ServiceCategoryId { get; set; }
        [Display(Name = "使用者")]
        public string MemberName { get; set; }
        [Display(Name = "評分")]
        public int Rating { get; set; }
        [Display(Name = "評論")]
        public string Text { get; set; }
        [Display(Name = "評論時間")]
        public DateTime CommentDateTime { get; set; }
        [Display(Name = "服務類型")]
        public string ServiceCategoryName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team1.ViewModels
{
    public class PackageVM
    {
        [Key]
        [Display(Name = "產品編號")]
        public int Id { get; set; }

        [Display(Name = "產品名稱")]
        public string Name { get; set; }
        [Display(Name = "價格")]
        public int Price { get; set; }
        [Display(Name = "最低成團")]
        public int LowestGo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "報名截止日")]
        public DateTime ApplyEndDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "報名開始日")]
        public DateTime ApplyBeginDate { get; set; }
        [Display(Name = "可賣")]
        public int CanSold { get; set; }
        [Display(Name = "總數")]
        public int TotalNum { get; set; }

        [Display(Name = "圖片")]
        public string Image { get; set; }

        [Display(Name = "描述")]
        public string Description { get; set; }

        [Display(Name = "注意事項")]
        public string Alert { get; set; }

        [Display(Name = "費用說明")]
        public string PriceDescription { get; set; }
    }
    public class PackageInsertVM
    {
        [Key]
        [Display(Name = "產品編號")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "產品名稱")]
        public string Name { get; set; }
        [Display(Name = "價格")]
        public int Price { get; set; }
        [Display(Name = "最低成團")]
        public int LowestGo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "報名截止日")]
        public DateTime ApplyEndDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "報名開始日")]
        public DateTime ApplyBeginDate { get; set; }
        [Display(Name = "可賣")]
        public int CanSold { get; set; }
        [Display(Name = "總數")]
        public int TotalNum { get; set; }
        [Display(Name = "圖片")]
        public string Image { get; set; }
 
        [Display(Name = "描述")]
        public string Description { get; set; }

        [Display(Name = "注意事項")]

        public string Alert { get; set; }

        [Display(Name = "費用說明")]
        public string PriceDescription { get; set; }
    }
}
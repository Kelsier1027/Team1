using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team1.Models.DTO
{
    public class AttractionSearchDTO
    {
        //搜尋
        public string Keyword { get; set; }
        public int? CategoryId { get; set; } = 0;
        //排序
        public string SortBy { get; set; }
        public string SortDirection { get; set; }
        //分頁
        public int? Page { get; set; } = 1;
        public int? PageSize { get; set; } = 12;
    }
}
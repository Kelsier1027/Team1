using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team1.個人.Huang.Entities
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ServiceCategoryId { get; set; }
        public string MemberName { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
        public DateTime CommentDateTime { get; set; }
        public string ServiceCategoryName { get; set; }
    }
}
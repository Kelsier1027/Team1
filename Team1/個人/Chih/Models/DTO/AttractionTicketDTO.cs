using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team1.Models.DTO
{
    public class AttractionTicketDTO
    {
        public int Id { get; set; }

        public int AttractionId { get; set; }

        public decimal Price { get; set; }

        public int Discount { get; set; }

        public string AttractionTicketType { get; set; }

        public bool TicketStatus { get; set; }
    }
}
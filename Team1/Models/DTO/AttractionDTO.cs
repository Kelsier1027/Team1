﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team1.Models.DTO
{
    public class AttractionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
    }
}
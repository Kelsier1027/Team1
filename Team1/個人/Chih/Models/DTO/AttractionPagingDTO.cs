using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Team1.Models.EFModel;

namespace Team1.Models.DTO
{
    public class AttractionPagingDTO { 
    
        public int TotalPages {  get; set; }
        public List<AttractionDTO> Attractions { get; set; }    
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace authpark.Models
{
    public class VaccanciesVM
    {
        public int LocationId { get; set; }
        
        public string Name { get; set; }
       
        public int TotalVacancies { get; set; }
        public int Reserved { get; set; }
    }
}
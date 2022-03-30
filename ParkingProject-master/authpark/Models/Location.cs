using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace authpark.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public int TotalVacancies { get; set; }
        [Required]

        public String Lat { get; set; }
        [Required]

        public String Long { get; set; }  
        [Required]
        [MaxLength(350)]
        public String Address { get; set; }
        [DataType(DataType.Currency)]
        [Required]

        public String Price { get; set; }
        [Required]

        public bool IsActive { get; set; }

    }
}
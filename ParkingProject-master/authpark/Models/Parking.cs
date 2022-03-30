using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace authpark.Models
{
    public class Parking
    {
       
        public int ParkingId { get; set; }

        public String UserId { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]

        public String VehicalRegNo { get; set; }
       
        public System.Nullable<DateTime>  CheckinTime { get; set; }
        public System.Nullable<DateTime> CheckoutTime { get; set; }
        public String ParkingStatus { get; set; }
        public virtual ApplicationUser Users_Table{ get; set; }
        public virtual Location Location_Table { get; set; }
       

    }
}
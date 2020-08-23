using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClimbingApp.Models
{


    public class PullUp
    {

        public int PullUpID { get; set; }

        [Required]
        [Display(Name = "Maximum Number of Pullups")]
        public int NPullUp { get; set; }

        [Required]
        public int StatID { get; set; }

        [Display(Name = "Date")]
        public DateTime ModifyDate { get; set; }

        [JsonIgnore]
        // Account has 1 customer
        public virtual Stat Stat { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClimbingApp.Models
{


    public class PushUp
    {

        public int PushUpID { get; set; }

        [Required]
        [Display(Name = "Maximum Number of Pushups")]
        public int NPushUp { get; set; }

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

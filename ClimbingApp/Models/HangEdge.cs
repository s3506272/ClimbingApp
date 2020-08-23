using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClimbingApp.Models
{


    public class HangEdge
    {

        public int HangEdgeID { get; set; }

        [Required]
        [Display(Name = "Maximum Number of Pushups")]
        public int NHangEdge { get; set; }

        [Required]
        public int StatID { get; set; }

        [JsonIgnore]
        // Account has 1 customer
        public virtual Stat Stat { get; set; }

        [Display(Name = "Date")]
        public DateTime ModifyDate { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

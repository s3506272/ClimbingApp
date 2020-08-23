using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClimbingApp.Models
{
    public class BoulderAverage
    {

        [Display(Name = "Highest Grade climbed")]
        public BoulderingClimbingGrade BoulderAverageID { get; set; }

        [Required]
        [Display(Name = "Average Number of Pullups")]
        public int PullUps { get; set; }

        [Display(Name = "Maximum Number of Pushups")]
        public int PushUps { get; set; }

        [Display(Name = "Smallest hangboard edge")]
        public int HangEdge { get; set; }

        [Display(Name = "Maximum weight on hangboard edge")]
        public int HangWeight { get; set; }

        [Display(Name = "Date")]
        public DateTime ModifyDate { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}

using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClimbingApp.Models
{
    public class SportAverage
    {
        [Display(Name = "Highest Grade climbed")]
        public SportClimbingGrade SportAverageID { get; set; }

        [Required]
        [Display(Name = "Average Number of Pullups")]
        public int PullUps { get; set; }

        [Display(Name = "Maximum Number of Pushups")]
        public int PushUps { get; set; }

        [Display(Name = "Smallest hangboard edge")]
        public int HangEdge { get; set; }

        [Display(Name = "Maximum weight on hangboard edge")]
        public int HangWeight { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}

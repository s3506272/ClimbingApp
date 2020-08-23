using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimbingApp.Models
{


    public class Stat
    {

        [Required]
        public int StatID { get; set; }

        [Display(Name = "Maximum Number of Pullups")]
        public int PullUp { get; set; } = 0;

        [Display(Name = "Maximum Number of Pushups")]
        public int PushUp { get; set; } = 0;

        [Display(Name = "Smallest hangboard edge")]
        public int HangEdge { get; set; } = 0;

        [Display(Name = "Maximum weight on hangboard edge")]
        public int HangWeight { get; set; } = 0;


        [Display(Name = "Highest Grade climbed")]
        public SportClimbingGrade HighestSportGrade { get; set; }

        [Display(Name = "Highest Grade climbed")]
        public BoulderingClimbingGrade HighestBoulderingGrade { get; set; }

        [Display(Name = "Date")]
        public DateTime ModifyDate { get; set; }

        public string UserID { get; set; }



        [JsonIgnore]
        // Account has 1 customer
        public virtual User User { get; set; }

        public virtual List<PullUp> UserPullUPs { get; set; }

        public virtual List<PushUp> UserPushUps { get; set; }
        public virtual List<HangEdge> UserHangEdges { get; set; }
        public virtual List<HangWeight> UserHangWeights { get; set; }


        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

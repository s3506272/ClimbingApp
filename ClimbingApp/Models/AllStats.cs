using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimbingApp.Models
{


    public class AllStats
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string UserID { get; set; }
        // Account has 1 customer
        public virtual User User { get; set; }

        [Required]
        [Display(Name = "Maximum Number of Pullups")]
        public int PullUps { get; set; }

        [Display(Name = "Maximum Number of Pushups")]
        public int PushUps { get; set; }

        [Display(Name = "Smallest hangboard edge")]
        public int HangEdge { get; set; }

        [Display(Name = "Maximum weight on hangboard edge")]
        public int HangWeight { get; set; }

        [Display(Name = "Highest Grade climbed")]
        public SportClimbingGrade HighestSportGrade { get; set; }

        [Display(Name = "Highest Grade climbed")]
        public BoulderingClimbingGrade HighestBoulderingGrade { get; set; }

        [Display(Name = "Date")]
        public DateTime ModifyDate { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

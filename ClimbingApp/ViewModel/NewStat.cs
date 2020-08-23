using ClimbingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClimbingApp.ViewModel
{
    public class NewStat
    {


        public int PullUp { get; set; }
        public int PushUp { get; set; }
        public int HangEdge { get; set; }
        public int HangWeight { get; set; }
        public string[] xLabels { get; set; }
        public string[] yLabels { get; set; }

        public IEnumerable<BoulderingClimbingGrade> BGrades { get; set; }
        public IEnumerable<SportClimbingGrade> SGrades { get; set; }

        [JsonIgnore]
        public Stat UserStat { get; set; }

    }
}

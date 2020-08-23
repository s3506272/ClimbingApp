using ClimbingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClimbingApp.ViewModel
{
    public class StatsAverage
    {


        public List<int> BPullUps { get; set; }
        public List<int> BPushUps { get; set; }
        public List<int> BHangEdge { get; set; }
        public List<int> BHangWeight { get; set; }
        public List<string> Blabels { get; set; }

        public List<int> SPullUps { get; set; }
        public List<int> SPushUps { get; set; }
        public List<int> SHangEdge { get; set; }
        public List<int> SHangWeight { get; set; }
        public List<string> Slabels { get; set; }

        public string[] xLabels { get; set; }
        public string[] yLabels { get; set; }

        public IEnumerable<BoulderingClimbingGrade> BGrades { get; set; }
        public IEnumerable<SportClimbingGrade> SGrades { get; set; }
        public IEnumerable<BoulderAverage> BoulderAverage { get; set; }
        public IEnumerable<SportAverage> SportAverage { get; set; }

        [JsonIgnore]
        public Stat UserStat { get; set; }


    }
}

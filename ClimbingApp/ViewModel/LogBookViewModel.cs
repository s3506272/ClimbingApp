using ClimbingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClimbingApp.ViewModel
{
    public class LogBookViewModel
    {

        public string UserId { get; set; }


        public List<Log> Logs { get; set; }

        public List<Boulder> Boulders { get; set; }

        public List<Sport> SportClimbs { get; set; }

    }
}

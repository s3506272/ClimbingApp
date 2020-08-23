using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClimbingApp.Models;
using Newtonsoft.Json;

namespace ClimbingApp.Models
{
    public enum ClimbType
    {
        [Display(Name = "Sport")]
        [Description("Sport")]
        Sport,
        [Display(Name = "Boulder")]
        [Description("Boulder")]
        Boulder
    }

    public class Log
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string LogID { get; set; }

        [Required, Display(Name = "Type")]
        public ClimbType Type { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime ModifyDate { get; set; }

        public int? BoulderID { get; set; }
        public virtual Boulder Boulder { get; set; }

        public int? SportID { get; set; }

        public virtual Sport Sport { get; set; }

        public string UserID { get; set; }
        public virtual User User { get; set; }

    }
}
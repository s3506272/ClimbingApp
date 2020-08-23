using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ClimbingApp.Models
{

    public enum BoulderingClimbingGrade
    {
        [Display(Name = "V0")]
        [Description("V0")]
        V0,
        [Display(Name = "V1")]
        [Description("V1")]
        V1,
        [Display(Name = "V2")]
        [Description("V2")]
        V2,
        [Display(Name = "V3")]
        [Description("V3")]
        V3,
        [Display(Name = "V4")]
        [Description("V4")]
        V4,
        [Display(Name = "V5")]
        [Description("V5")]
        V5,
        [Display(Name = "V6")]
        [Description("V6")]
        V6,
        [Display(Name = "V7")]
        [Description("V7")]
        V7,
        [Display(Name = "V8")]
        [Description("V8")]
        V8,
        [Display(Name = "V9")]
        [Description("V9")]
        V9,
        [Display(Name = "V10")]
        [Description("V10")]
        V10,
        [Display(Name = "V11")]
        [Description("V11")]
        V11,
        [Display(Name = "V12")]
        [Description("V12")]
        V12,
        [Display(Name = "V13")]
        [Description("V13")]
        V13,
        [Display(Name = "V14")]
        [Description("V14")]
        V14,
        [Display(Name = "V15")]
        [Description("V15")]
        V15,
        [Display(Name = "V16")]
        [Description("V16")]
        V16,
        [Display(Name = "V17")]
        [Description("V17")]
        V17
    }
    public class Boulder
    {


        [Display(Name = "ID")]
        public int BoulderID { get; set; }

        [Display(Name = "Boulder Name")]
        public string Name { get; set; }

        [Display(Name = "Area")]
        public string Area { get; set; }

        [Display(Name = "Latitude")]
        public string Latitude { get; set; }

        [Display(Name = "Longitude")]
        public string Longitude { get; set; }

        [Required, Display(Name = "Bouldering Grade")]
        public BoulderingClimbingGrade BoulderingClimbingGrade { get; set; }

        [Required, Display(Name = "Consesnsus Grade")]
        public int ConsensusGrade { get; set; }

        [Display(Name = "Date")]
        public DateTime ModifyDate { get; set; }

        public virtual List<Log> Logs { get; set; }
    }
}

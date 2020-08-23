using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ClimbingApp.Models
{

    public enum SportClimbingGrade
    {
        [Display(Name = "10")]
        [Description("10")]
        Ten = 10,
        [Display(Name = "11")]
        [Description("11")]
        Eleven = 11,
        [Display(Name = "12")]
        [Description("12")]
        Twelve = 12,
        [Display(Name = "13")]
        [Description("13")]
        Thirteen = 13,
        [Display(Name = "14")]
        [Description("14")]
        Fourteen = 14,
        [Display(Name = "15")]
        [Description("15")]
        Fifteen = 15,
        [Display(Name = "16")]
        [Description("16")]
        Sixteen = 16,
        [Display(Name = "17")]
        [Description("17")]
        Seventeen = 17,
        [Display(Name = "18")]
        [Description("18")]
        Eighteen = 19,
        [Display(Name = "19")]
        [Description("19")]
        Nineteen = 19,
        [Display(Name = "20")]
        [Description("20")]
        Twenty = 20,
        [Display(Name = "21")]
        [Description("21")]
        TwentyOne,
        [Display(Name = "22")]
        [Description("22")]
        TwentyTwo =22,
        [Display(Name = "23")]
        [Description("23")]
        TwentyThree = 23,
        [Display(Name = "24")]
        [Description("24")]
        TwentyFour = 24,
        [Display(Name = "25")]
        [Description("25")]
        TwentyFive = 25,
        [Display(Name = "26")]
        [Description("26")]
        TwentySix = 26,
        [Display(Name = "27")]
        [Description("27")]
        TwentySeven = 27,
        [Display(Name = "28")]
        [Description("28")]
        TwentyEight = 28,
        [Display(Name = "29")]
        [Description("29")]
        TwentyNine = 29,
        [Display(Name = "30")]
        [Description("30")]
        Thirty = 30,
        [Display(Name = "31")]
        [Description("31")]
        Thirtyone = 31,
        [Display(Name = "32")]
        [Description("32")]
        Thirtytwo = 32,
        [Display(Name = "33")]
        [Description("33")]
        Thirtythree = 33,
        [Display(Name = "34")]
        [Description("34")]
        Thirtyfour = 34,
        [Display(Name = "35")]
        [Description("35")]
        Thirtyfive = 35,
        [Display(Name = "35+")]
        [Description("35+")]
        Thirtyplus = 36
    }
    public class Sport
    {

        [Display(Name = "ID")]
        public int SportID { get; set; }

        [Display(Name = "Sport route Name")]
        public string Name { get; set; }

        [Display(Name = "Area")]
        public string Area { get; set; }

        [Display(Name = "Latitude")]
        public string Latitude { get; set; }

        [Display(Name = "Longitude")]
        public string Longitude { get; set; }

        [Required, Display(Name = "Sport Grade")]
        public SportClimbingGrade SportClimbingGrade { get; set; }

        [Required, Display(Name = "Consesnsus Grade")]
        public int ConsensusGrade { get; set; }

        [Display(Name = "Date")]
        public DateTime ModifyDate { get; set; }

        public virtual List<Log> Logs { get; set; }
    }
}

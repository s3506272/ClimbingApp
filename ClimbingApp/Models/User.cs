using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimbingApp.Models
{
    public class User
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserID { get; set; }

        [Display(Name = "Your approximate weight")]
        public int Weight { get; set; }

        [Display(Name = "Your approximate weight")]
        public int Height { get; set; }

        [Display(Name = "Ape Index")]
        public int ApeIndex { get; set; }

        [Display(Name = "Date")]
        public DateTime ModifyDate { get; set; }

        public virtual Stat Stat { get; set; }

        public virtual List<Log> Logs { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}

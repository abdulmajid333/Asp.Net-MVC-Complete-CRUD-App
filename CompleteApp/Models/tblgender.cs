using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompleteApp.Models
{
    public class tblgender
    {
        [Key]
        public int genderid { get; set; }
        public string gendername { get; set; }
    }
}
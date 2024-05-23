using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompleteApp.Models
{
    public class tblstate
    {
        [Key]
        public int stateid { get; set; }
        public string statename { get; set; }
        public int countryid { get; set; }
    }
}
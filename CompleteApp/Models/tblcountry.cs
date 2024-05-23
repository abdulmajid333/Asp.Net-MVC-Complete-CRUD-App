using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompleteApp.Models
{
    public class tblcountry
    {
        [Key]
        public int countryid { get; set; }
        public string countryname { get; set; }
    }
}
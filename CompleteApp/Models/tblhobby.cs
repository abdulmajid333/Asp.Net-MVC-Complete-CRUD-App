using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompleteApp.Models
{
    public class tblhobby
    {
        [Key]
        public int hobbyid { get; set; }
        public string hobbyname { get; set; }
    }
}
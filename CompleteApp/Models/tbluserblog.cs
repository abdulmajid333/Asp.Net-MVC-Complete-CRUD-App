using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompleteApp.Models
{
    public class tbluserblog
    {
        [Key]
        public int blogid { get; set; }
        public string blogtitle { get; set; }
        public string blogimage { get; set; }
        public string blogdescription { get; set; }
    }
}
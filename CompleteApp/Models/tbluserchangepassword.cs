using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompleteApp.Models
{
    public class tbluserchangepassword
    {
        public string oldpassword { get; set; }
        public string newpassword { get; set; }
        public string confirmnewpassword { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompleteApp.Models
{
    public class tbluser1
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string useremail { get; set; }
        public string userpassword { get; set; }
        public int usermobilenumber { get; set; }
        public int userage { get; set; }
        public int usercountry { get; set; }
        public int userstate { get; set; }
        public int usergender { get; set; }
        public string userhobby { get; set; }
        public string userdp { get; set; }
        public List<tblgender> lstgender { get; set; }
        public List<tblhobby1> lsthobby1 { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompleteApp.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("dbca")
        {
            
        }

        public DbSet<tbluser> tblusers { get; set; }
        public DbSet<tblcountry> tblcountries { get; set; }
        public DbSet<tblstate> tblstates { get; set; }
        public DbSet<tblgender> tblgenders { get; set; }
        public DbSet<tblhobby> tblhobby { get; set; }
        public DbSet<tbluserblog> tbluserblogs { get; set; }
    }
}
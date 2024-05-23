using CompleteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompleteApp.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome
        DatabaseContext _db = new DatabaseContext();
        public ActionResult Index(tbluser _us)
        {
            int iidd = Convert.ToInt32(Session["ID"]);
            var data = (from a in _db.tblusers where a.userid == iidd select a).ToList();
            ViewBag.name = data[0].username;
            return View(data);
        }
    }
}
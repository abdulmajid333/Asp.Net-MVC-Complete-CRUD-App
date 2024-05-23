using CompleteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompleteApp.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin

        DatabaseContext _db = new DatabaseContext();

        [HttpGet]
        public ActionResult UserLoginForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLoginForm(tbluser _us)
        {
            

            var data = (from a in _db.tblusers where a.useremail == _us.useremail && a.userpassword == _us.userpassword select a).ToList();

            if(data.Count > 0)
            {
                Session["ID"] = data[0].userid;
                return RedirectToAction("Index","UserHome");
            }
            else
            {
                ViewBag.msg = "Login Failed !!";
                return View();
                
            }
            
        }

        public ActionResult UserLogout()
        {
            //Session.Remove("ID");
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}
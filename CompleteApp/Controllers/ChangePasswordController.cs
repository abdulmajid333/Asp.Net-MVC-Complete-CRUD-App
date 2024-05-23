using CompleteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompleteApp.Controllers
{
    public class ChangePasswordController : Controller
    {
        // GET: ChangePassword

        DatabaseContext _db = new DatabaseContext();

        [HttpGet]
        public ActionResult UserChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserChangePassword(tbluserchangepassword _uscp)
        {
            int uid = Convert.ToInt32(Session["ID"]);
            var data = _db.tblusers.Find(uid);


                if(_uscp.oldpassword == data.userpassword)
                {
                    if(_uscp.newpassword == _uscp.confirmnewpassword)
                    {
                        data.userpassword = _uscp.newpassword;
                        _db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                        _db.SaveChanges();
                        return RedirectToAction("Index","UserHome");
                    }
                    else
                    {
                        ViewBag.msg = "New Password And Confirm New Password Not Match";
                        return View();
                    }
                }
                else
                {
                    ViewBag.msg = "Old Password Not Match";
                    return View();
                }
            


            
        }
    }
}
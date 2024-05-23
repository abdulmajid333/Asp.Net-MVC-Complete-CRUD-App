using CompleteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace CompleteApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        DatabaseContext _db = new DatabaseContext();

        // --------------------------------------- For Insert -------------------------------------------

        [HttpGet]
        public ActionResult UserInsert()
        {
            tbluser1 _us1 = new tbluser1();

            ViewBag.ctr = _db.tblcountries.ToList(); // for country drop down
            
            _us1.lstgender = (from a in _db.tblgenders select a).ToList(); // for gender

            var data = _db.tblhobby.ToList(); // for hobby

            _us1.lsthobby1 = data.Select(x=> new tblhobby1
            {
                hobbyid = x.hobbyid,
                hobbyname = x.hobbyname,
                ischecked = false
            }).ToList();

            return View(_us1);
        }

        [HttpPost]
        public ActionResult UserInsert(tbluser1 _us1 , HttpPostedFileBase userdpfile)
        {

            // ------------------ for hobby -----------------------

            string hobs = "";

            foreach(var i in _us1.lsthobby1)
            {
                if (i.ischecked == true)
                {
                    hobs += i.hobbyname + "," ;
                }
            }
            hobs = hobs.TrimEnd(',');

            //---------------- for user dp or file --------------------

            string fn = Path.GetFileName(userdpfile.FileName);
            userdpfile.SaveAs(Path.Combine(Server.MapPath("~/userpic/"),fn));
            

            // ---------------- for transfer data from tbluser1 to tbluser ------------------- 

            tbluser _us = new tbluser();

            _us.userid = _us1.userid;
            _us.username = _us1.username;
            _us.useremail = _us1.useremail;
            _us.userpassword = _us1.userpassword;
            _us.usermobilenumber = _us1.usermobilenumber;
            _us.userage = _us1.userage;
            _us.usercountry = _us1.usercountry;
            _us.userstate = _us1.userstate;
            _us.usergender = _us1.usergender;
            _us.userhobby = hobs;
            _us.userdp = "~/userpic/" + fn; // file save with path



            _db.tblusers.Add(_us);
            _db.SaveChanges();

            return RedirectToAction("UserShow");
        }

        // -------------------------------------- For Show --------------------------------------

        public ActionResult UserShow()
        {
            var data = (from a in _db.tblusers
                        join b in _db.tblcountries on a.usercountry equals b.countryid
                        join c in _db.tblstates on a.userstate equals c.stateid
                        join d in _db.tblgenders on a.usergender equals d.genderid
                        select new tbluserjoin
                        {
                            userid = a.userid,
                            username = a.username,
                            useremail = a.useremail,
                            userpassword = a.userpassword,
                            usermobilenumber = a.usermobilenumber,
                            userage = a.userage,
                            usercountry = b.countryname,
                            userstate = c.statename,
                            usergender = d.gendername,
                            userhobby = a.userhobby,
                            userdp = a.userdp
                        }).ToList();



            return View(data);
        }

        // ------------------------------------ For Edit or Update -------------------------------

        [HttpGet]
        public ActionResult UserEdit(int id=0)
        {

            tbluser1 _us1 = new tbluser1();

            ViewBag.ctr = _db.tblcountries.ToList(); // for country drop down

            _us1.lstgender = (from a in _db.tblgenders select a).ToList(); // for gender

            var data = _db.tblhobby.ToList(); // for hobby
            _us1.lsthobby1 = data.Select(x => new tblhobby1
            {
                hobbyid = x.hobbyid,
                hobbyname = x.hobbyname,
                ischecked = false
            }).ToList();



            if (id > 0)
            {
                var data1 = (from a in _db.tblusers where a.userid == id select a).ToList();

                _us1.userid = data1[0].userid;
                _us1.username = data1[0].username;
                _us1.useremail = data1[0].useremail;
                _us1.userpassword = data1[0].userpassword;
                _us1.usermobilenumber = data1[0].usermobilenumber;
                _us1.userage = data1[0].userage;
                _us1.usercountry = data1[0].usercountry;
                _us1.userstate = data1[0].userstate;
                _us1.usergender = data1[0].usergender;

                string[] hobsarr = data1[0].userhobby.Split(',');

                foreach(var a in _us1.lsthobby1)
                {
                    foreach(var b in hobsarr)
                    {
                        if(a.hobbyname == b)
                        {
                            a.ischecked = true;
                        }
                    }
                }


                ViewBag.dp = data1[0].userdp;
                _us1.userdp = data1[0].userdp;
            }

            ViewBag.stt = (from a in _db.tblstates where a.countryid == _us1.usercountry select a).ToList();

            return View(_us1);
        }

        [HttpPost]
        public ActionResult UserEdit(tbluser1 _us1, HttpPostedFileBase userdpfile)
        {
            // ------------------ for hobby -----------------------

            string hobs = "";

            foreach (var i in _us1.lsthobby1)
            {
                if (i.ischecked == true)
                {
                    hobs += i.hobbyname + ",";
                }
            }
            hobs = hobs.TrimEnd(',');

            if (_us1.userid > 0)
            {
                


                // ---------------- for transfer data from tbluser1 to tbluser ------------------- 

                tbluser _us = new tbluser();

                _us.userid = _us1.userid;
                _us.username = _us1.username;
                _us.useremail = _us1.useremail;
                _us.userpassword = _us1.userpassword;
                _us.usermobilenumber = _us1.usermobilenumber;
                _us.userage = _us1.userage;
                _us.usercountry = _us1.usercountry;
                _us.userstate = _us1.userstate;
                _us.usergender = _us1.usergender;
                _us.userhobby = hobs;

                if (userdpfile != null)
                {
                    string fn = Path.GetFileName(userdpfile.FileName);
                    userdpfile.SaveAs(Path.Combine(Server.MapPath("~/userpic/"), fn));
                    System.IO.File.Delete(Server.MapPath(_us1.userdp));
                    _us.userdp = "~/userpic/" + fn; // file save with path
                }
                else
                {
                    _us.userdp = _us1.userdp;
                }

                _db.Entry(_us).State = System.Data.Entity.EntityState.Modified;

            }


            
            _db.SaveChanges();

            return RedirectToAction("UserShow");
        }

        // -------------------------------------- For Delete -------------------------------------

        [HttpGet]
        public ActionResult UserDelete(int id=0)
        {
            tbluser _us = new tbluser();

            var data = _db.tblusers.Where(x=>x.userid == id).ToList();
            
            if(id > 0)
            {
                _us.userid = data[0].userid;
                _us.username = data[0].username;
                _us.useremail = data[0].useremail;
                _us.userpassword = data[0].userpassword;
                _us.usermobilenumber = data[0].usermobilenumber;
                _us.userage = data[0].userage;
                _us.usercountry = data[0].usercountry;
                _us.userstate = data[0].userstate;
                _us.usergender = data[0].usergender;
                _us.userhobby = data[0].userhobby;
                _us.userdp = data[0].userdp;
            }

            return View(_us);

        }

        [HttpPost]
        public ActionResult UserDelete(tbluser _us)
        {

            
            if(_us.userid > 0)
            {
                var data = _db.tblusers.Find(_us.userid);
                _db.tblusers.Remove(data);
                System.IO.File.Delete(Server.MapPath(_us.userdp));
                _db.SaveChanges();
            }
            
            

            return RedirectToAction("UserShow");
        }

        // ----------------------------------- For get user state ------------------------------------

        public JsonResult GetUserState(int Cid)
        {
            var data = (from a in _db.tblstates where a.countryid == Cid select a).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
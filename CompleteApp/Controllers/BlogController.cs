using CompleteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace CompleteApp.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        DatabaseContext _db = new DatabaseContext();

        [HttpGet]
        public ActionResult AddUserBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUserBlog(tbluserblog _usbg, HttpPostedFileBase blogimagefile)
        {
            string bgfn = Path.GetFileName(blogimagefile.FileName);



            blogimagefile.SaveAs(Path.Combine(Server.MapPath("~/Blogimages/"),bgfn));
            _usbg.blogimage = "~/Blogimages/" + bgfn;

            _db.tbluserblogs.Add(_usbg);
            _db.SaveChanges();
            return RedirectToAction("ShowBlog");
        }

        public ActionResult ShowBlog(int pageNumber = 1)
        {

            ViewBag.pageNumber = pageNumber;

            var data = _db.tbluserblogs.ToList();

            ViewBag.totalpages = Math.Ceiling(data.Count / 5.0);

            data = data.Skip( ( pageNumber - 1 ) * 5 ).Take(5).ToList();

            

            return View(data);

            
        }

        
    }
}
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Details(long id)
        {
            HarvestifyEntities2 db = new HarvestifyEntities2();
            User u = db.Users.Where(temp => temp.Id == id).FirstOrDefault();
            
            return View(u);
        }

        public ActionResult edit(long id)
        {
            HarvestifyEntities2 db = new HarvestifyEntities2();
            User u = db.Users.Where(temp => temp.Id == id).FirstOrDefault();
            return View(u);
        }

        [HttpPost]
        public ActionResult edit(User us)
        {
            HarvestifyEntities2 db = new HarvestifyEntities2();
            User u = db.Users.Where(temp => temp.Id == us.Id).FirstOrDefault();
            u.UserName = us.UserName;
            //u.Email = us.Email;
            u.Mobile = us.Mobile;
            u.Address = us.Address;
            db.SaveChanges();
            return RedirectToAction("Dashboard", "AdminDashboard");
        }

        public ActionResult Delete(long id)
        {
            HarvestifyEntities2 db = new HarvestifyEntities2();
            User u = db.Users.Where(temp => temp.Id == id).FirstOrDefault();
            return View(u);
        }


        [HttpPost]
        public ActionResult Delete(long id, User us)
        {
            HarvestifyEntities2 db = new HarvestifyEntities2();
            User u = db.Users.Where(temp => temp.Id == id).FirstOrDefault();
            db.Users.Remove(u);
            db.SaveChanges();
            return RedirectToAction("Dashboard", "AdminDashboard");
        }
        //public ActionResult UserActivateStatusFalse(long id, User us)
        //{
        //    HarvestifyEntities1 db = new HarvestifyEntities1();
        //    User u = db.Users.Where(temp => temp.Id == id).FirstOrDefault();
        //    us.isActive = false;
        //    db.SaveChanges();
        //    return RedirectToAction("Dashboard", "AdminDashboard");
        //}
        //public ActionResult UserActivateStatusTrue(long id, User us)
        //{
        //    HarvestifyEntities1 db = new HarvestifyEntities1();
        //    User u = db.Users.Where(temp => temp.Id == id).FirstOrDefault();
        //    us.isActive = true;
        //    db.SaveChanges();
        //    return RedirectToAction("Dashboard", "AdminDashboard");
        //}

        //public ActionResult UserActivateStatus(long id)
        //{
        //    HarvestifyEntities1 db = new HarvestifyEntities1();
        //    User u = db.Users.Where(temp => temp.Id == id).FirstOrDefault();
        //    return View(u);
        //}


        //[HttpPost]
        //public ActionResult UserActivateStatus(long id, User us, bool isActive)
        //{
        //    HarvestifyEntities1 db = new HarvestifyEntities1();
        //    User u = db.Users.Where(temp => temp.Id == id).FirstOrDefault();
        //    us.isActive = isActive;
        //    db.SaveChanges();
        //    return RedirectToAction("Dashboard", "AdminDashboard");
        //}

        public ActionResult logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("index", "login");
        }
    }
}
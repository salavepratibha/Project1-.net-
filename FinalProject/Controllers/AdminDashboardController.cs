using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FinalProject.Controllers
{
    public class AdminDashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard(string search = "", int PageNo = 1)
        {
            HarvestifyEntities2 db = new HarvestifyEntities2();
            // List<User> UsersData = db.Users.Where.(temp => temp.user)ToList();
            List<User> UserData = db.Users.Where(temp => temp.UserName.Contains(search)).ToList();
            //return View(UserData);


            int NoOfRecordsPerPage = 3;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(UserData.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            UserData = UserData.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return View(UserData);
        }

        public ActionResult UserActivateStatus(long id, bool isActive)
        {
            HarvestifyEntities2 db = new HarvestifyEntities2();
            User u = db.Users.Where(temp => temp.Id == id).FirstOrDefault();
            u.isActive = isActive;
            db.SaveChanges();
            return RedirectToAction("Dashboard", "AdminDashboard");
        }


        
    }

}
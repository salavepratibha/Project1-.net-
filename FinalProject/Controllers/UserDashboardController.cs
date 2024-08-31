using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace FinalProject.Controllers
{
    public class UserDashboardController : Controller
    {
        // GET: UserDashboard
        public ActionResult Dashboard()
        {
            string displayimg = (string)Session["eId"]; 
            string mainconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select * from [dbo].[Users] where Email ='" + displayimg + "' or Mobile ='" + displayimg + "'";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlcomm.Parameters.AddWithValue("Uemail", Session["eId"].ToString());

            SqlDataReader sdr = sqlcomm.ExecuteReader();
            if (sdr.Read())
            {

                string s1 = sdr["Mobile"].ToString();
                string s2 = sdr["UserName"].ToString();
                string s8 = sdr["Email"].ToString();
                //string s6 = sdr["Address"].ToString();
               // string s5 = sdr["Education"].ToString();
                string s = sdr["Uimg"].ToString();
                string s7 = sdr["Id"].ToString();
                
                ViewData["Uimg"] = s;
                ViewData["UserName"] = s2;
                ViewData["Mobile"] = s1;
               // ViewData["Education"] = s5;
               // ViewData["Address"] = s6;
                ViewData["Id"] = s7;
                ViewData["Email"] = s8;
                



            }
            sqlconn.Close();
            return View();
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
           // u.Email = us.Email;
            u.Mobile = us.Mobile;
           // u.Address = us.Address;
            db.SaveChanges();
            return RedirectToAction("Dashboard", "UserDashboard");
        }

    }
}
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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(LoginClass lc)
        {
            if (lc.Uemail == "admin@gmail.com" && lc.Upwd == "admin")
            {
                FormsAuthentication.SetAuthCookie(lc.Uemail, true);
                Session["eId"] = lc.Uemail.ToString();
                return RedirectToAction("Dashboard", "AdminDashboard");
            }
            else
            {
                string mainconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);
                string sqlquery = "select Email, Mobile, Password, isActive from [dbo].[Users] where (Email=@Uemail or Mobile=@Uemail) and Password=@Upwd and isActive = 'true' ";
                sqlconn.Open();
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                sqlcomm.Parameters.AddWithValue("@Uemail", lc.Uemail);
                sqlcomm.Parameters.AddWithValue("@Mobile", lc.Uemail);
                sqlcomm.Parameters.AddWithValue("@Upwd", lc.Upwd);
                SqlDataReader sdr = sqlcomm.ExecuteReader();
                if (sdr.Read())
                {
                    FormsAuthentication.SetAuthCookie(lc.Uemail, true);
                    Session["eId"] = lc.Uemail.ToString();
                    return RedirectToAction("Dashboard", "UserDashboard");
                }
                else
                {
                    ViewData["Message"] = "Invalid Credintials pr Account Deactivated!";
                }
                sqlconn.Close();
            }
            return View();

        }
    }
}
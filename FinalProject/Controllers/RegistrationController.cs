using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace FinalProject.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserClass uc, HttpPostedFileBase file)
        {

            string mainconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            uc.isActive = true;
            string sqlquery = "insert into [dbo].[Users] (UserName,Email,Password,Mobile,Uimg,isActive) values (@Uname,@Uemail,@Upwd,@Mobile,@Uimg,@isActive)";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@Uname", uc.Uname);
            sqlcomm.Parameters.AddWithValue("@Uemail", uc.Uemail);
            sqlcomm.Parameters.AddWithValue("@Upwd", uc.Upwd);
            sqlcomm.Parameters.AddWithValue("@Mobile", uc.Mobile);
            //sqlcomm.Parameters.AddWithValue("@Education", uc.Education);
            //sqlcomm.Parameters.AddWithValue("@Address", uc.Address);
            sqlcomm.Parameters.AddWithValue("@isActive", uc.isActive);
            if (file != null && file.ContentLength > 0)
            {
                string filename = Path.GetFileName(file.FileName);
                string imgpath = Path.Combine(Server.MapPath("/User-Images/"), filename);
                file.SaveAs(imgpath);
            }
            sqlcomm.Parameters.AddWithValue("@Uimg", "/User-Images/" + file.FileName);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
            ViewBag.message = "Registered Successfully";
            return RedirectToAction("Index", "Login");
            //Session["RegistrationSuccess"] = true;
            //Response.Redirect("/login/index");
            //ViewData["Message"] = "User Record " + uc.Uname + " is Saved Succesfully !";
            //return View();
        }

    }   
}
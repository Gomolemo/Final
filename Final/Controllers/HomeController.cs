using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Net;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Final.Models;


namespace Final.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        CompanyCaptureDBEntities1 db = new CompanyCaptureDBEntities1();
        
        public ActionResult Login(User_tbl user)
        {
            
            return View();
        }
         public JsonResult doesEmployeeNoExist(int empNo)
        {
            //should return false 
            //so that we can tell the client that employeeNo entered does not exist
            //and make sure that only existing users can onlu get the access to entering the password
           return Json(!db.User_tbl.Any(employee => employee.employeeNo == empNo),JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Company()
        {
        
            return View();
        }
        public ActionResult ForgotPassword()
        {

            return View();
        }
    }
}
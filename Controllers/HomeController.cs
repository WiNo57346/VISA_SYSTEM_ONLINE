using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VISA_SYSTEM_ONLINE.Models;
using Common;
namespace VISA_SYSTEM_ONLINE.Controllers
{

    public class HomeController : Controller
    {

        //clsConnectDB Login = new clsConnectDB();

        DB_VISAEntities db = new DB_VISAEntities();


        [HttpGet]
        public ActionResult Main()
        {
            return View();
        }




        [HttpGet]
        public ActionResult Input()
        {
            //if (Session["UserID"] != null)
            //{
             return View();
            //}
            //else
            //{
//                return RedirectToAction("Login");
          //  }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(VISA_User_Login objUser)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    var obj = db.VISA_User_Login.Where(a => a.Opno.Equals(objUser.Opno) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {                                    
                           
                            DateTime Now = DateTime.Now;
                            // Update Statement
                            var update = db.VISA_User_Login.Where(o => o.Opno == obj.Opno).FirstOrDefault();
                            if (update != null)
                            {
                            update.LastLoginDate = Now;                               
                            }

                        db.SaveChanges();

                        Session["UserID"] = obj.Opno.ToString();
                        Session["UserName"] = obj.OP_Name.ToString();
                        ViewBag.name = obj.OP_Name.ToString();
                        return View("Input");

                    }
                }
            }
            @ViewBag.Message = "OP DATA NOT FOUND !!";
            return View(objUser);
        }



    


    }
}




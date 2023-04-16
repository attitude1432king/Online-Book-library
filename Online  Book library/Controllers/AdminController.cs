using Online__Book_library.Bal;
using Online__Book_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online__Book_library.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        AdminHelper ah = new AdminHelper();
        StudentHelper sh=new StudentHelper();
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Register()
        {
            return View();
        }

       
        public JsonResult AdminRegister(AdminModel data)
        {
            return Json(ah.AdminRegister(data),JsonRequestBehavior.AllowGet);
        }

        public ViewResult Login()
        {
            return View();
        }

        public ActionResult CommonLogin(LoginModel data)
        { 
            if(ah.Login(data))
            {
                //return Json(ah.Login(data), JsonRequestBehavior.AllowGet);
                return RedirectToAction("Index");
                
            }
            else if(sh.Login(data))
            {
                // return Json(sh.Login(data), JsonRequestBehavior.AllowGet);
                return RedirectToAction("Index","Student");
            }
            else
            {
                //return Json("", JsonRequestBehavior.AllowGet);
                return RedirectToAction("Login");
            }
        }


    }
}
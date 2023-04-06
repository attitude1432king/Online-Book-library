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
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Registers(AdminModel data)
        {
            return Json(ah.AdminRegister(data),JsonRequestBehavior.AllowGet);
        }


    }
}
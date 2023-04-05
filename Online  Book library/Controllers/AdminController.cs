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

        public ViewResult Register(AdminModel data)
        {
            return View();
        }
    }
}
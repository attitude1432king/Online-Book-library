using Online__Book_library.Bal;
using Online__Book_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online__Book_library.Controllers
{
    public class StudentController : Controller
    {
        StudentHelper sh=new StudentHelper();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult StudentRegister(StudentModel data)
        {
            return Json(sh.Register(data),JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetBook()
        {
            List<BookModel> list_book = sh.GetStudentBook();
            return View();
        }

    }
}
using Online__Book_library.Bal;
using Online__Book_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online__Book_library.Controllers
{
    public class BookController : Controller
    {
        BookHelper bh = new BookHelper();
        // GET: Book

        public JsonResult GetBookCategory()
        {
               List<CategoryModel> list= bh.GetBookCategory();
            ViewBag.cate = list;
               return Json(ViewBag.cate, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllBook()
        {
            return Json(bh.GetAllBook(),JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(BookModel data)
        {
            return Json(bh.AddBook(data), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(BookModel data)
        {
            return Json(bh.UpdateBook(data), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(BookModel data)
        {
            return Json(bh.DeleteBook(data.c_book_id), JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Baithi3.DAL;
using Baithi3.Models;

namespace Baithi3.Controllers
{
    public class BookController : Controller
    {
        private BookDAL dal = new BookDAL();
        // GET: Book
        public ActionResult ListBooks()
        {
            
            List<Sach> ls = dal.ListSach();
            return View(ls);
        }
        [HttpGet]
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBook(Sach sa)
        {
            dal.CreateBook(sa);
            return View("ListBooks", dal.ListSach());
        }
        [HttpGet]
        public ActionResult EditBook(int ID)
        {
            
            List<Sach> ls = dal.ListSach();
            Sach sa = new Sach();
            for(int i = 0; i < ls.Count; i++)
            {
                if(ls[i].ID == ID)
                {
                    sa = ls[i];
                }
            }
            return View(sa);
        }
        [HttpPost]
        public ActionResult EditBook(Sach sa)
        {
            dal.EditBook(sa);
            return View("ListBooks", dal.ListSach());
        }
        public ActionResult DeleteBook(int ID)
        {
            dal.DeleteBook(ID);
            return View("ListBooks", dal.ListSach());
        }

        [HttpGet]
        public ActionResult FindBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FindBook(Sach sa)
        {
            
            return View("ListBooks", dal.FindBook(sa));

        }
    }
}
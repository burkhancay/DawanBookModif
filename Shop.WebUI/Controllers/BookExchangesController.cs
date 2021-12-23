using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop.Core.Models;
using Shop.DataAccess.SQL;

namespace Shop.WebUI.Controllers
{
    public class BookExchangesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: BookExchanges
        public ActionResult Index()
        {
            var bookExchanges = db.BookExchanges.Include(b => b.OldOwner).Include(b => b.Book);
            return View(bookExchanges.ToList());
        }

        // GET: BookExchanges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookExchange bookExchange = db.BookExchanges.Find(id);
            if (bookExchange == null)
            {
                return HttpNotFound();
            }
            return View(bookExchange);
        }

      
    }
}

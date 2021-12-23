using Shop.Core.Models;
using Shop.Core.ViewModels;
using Shop.DataAccess.SQL;
using Shop.DataAccess.SQL.LogicMetier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.WebUI.Controllers
{
    public class BooksController : Controller
    {
        IRepository<Book> bookDao;
        IRepository<Category> categoryDao;


        public BooksController()
        {
            bookDao = new SQLRepository<Book>(new MyContext());
            categoryDao = new SQLRepository<Category>(new MyContext());
        }

        // GET: Products
        //public ActionResult Index()
        //{
        //    List<Book> books = bookDao.Collection().ToList();
        //    return View(books);
        //}


        public ActionResult Create()
        {
            BookCategoriesViewModel viewModel = new BookCategoriesViewModel();
            viewModel.Book = new Book();
            viewModel.Categories = categoryDao.Collection();
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            else
            {
                if (image != null)
                {
                    int maxId;
                    try
                    {
                        maxId = bookDao.Collection().Max(b => b.Id);
                    }
                    catch (Exception)
                    {

                        maxId = 0;
                    }

                    int nextId = maxId + 1;

                   
                    book.Image = nextId + Path.GetExtension(image.FileName);
                    image.SaveAs(Server.MapPath("~/Content/prodImages/") + book.Image);
                }
                Utilisateur u = (Utilisateur)Session["User"];
                book.UtilisateurId = (int)Session["Id"];
                book.Disponibilite = true;
                //book.Utilisateur.UserName = u.UserName;
                
                bookDao.Insert(book);
                bookDao.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Edit(int id)
        {
            //On récupere le produit à modifier
            Book b = bookDao.FindById(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            else
            {
                BookCategoriesViewModel viewModel = new BookCategoriesViewModel();

                //On met à jour Produit de viewModel via le produit récuperer(à modifier)
                viewModel.Book = b;
                Session["Image"] = b.Image;

                viewModel.Categories = categoryDao.Collection();

                return View(viewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book, HttpPostedFileBase image)
        {
            if(!ModelState.IsValid)
            {
                return View(book);
            } else
            {
                if(image != null)
                {
                    book.Image = book.Id + Path.GetExtension(image.FileName);
                    image.SaveAs(Server.MapPath("~/Content/prodImages/") + book.Image);
                }else
                {
                    book.Image = (string)Session["Image"];
                }

                bookDao.Update(book);
                bookDao.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(int id)
        {
            Book b = bookDao.FindById(id);

            if(b == null)
            {
                return HttpNotFound();
            } else
            {
                return View(b);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Book prodToDelete = bookDao.FindById(id);

            if (prodToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                bookDao.DeleteById(id);
                bookDao.SaveChanges();

                return RedirectToAction("Index");
            }
        }

    }
}
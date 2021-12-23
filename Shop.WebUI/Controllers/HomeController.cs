using Shop.Core.Models;
using Shop.Core.ViewModels;
using Shop.DataAccess.SQL;
using Shop.DataAccess.SQL.LogicMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Shop.WebUI.Controllers
{
    public class HomeController : Controller
    {
       
        IRepository<Book> bookDao;
        IRepository<Category> categoryDao;
        IBookRepository bookRepository;
        const int MAX_BY_PAGE = 5; // nombre d'éléments dans la page

        public HomeController()
        {
           
            bookDao = new SQLRepository<Book>(new MyContext());
            categoryDao = new SQLRepository<Category>(new MyContext());
            bookRepository = new BookRepository(new MyContext());
        }

        /*   public ActionResult Index(string Category = null)
           {
               List<Product> products;
               List<Category> categories = categoryDao.Collection().ToList();

               //Si Category est égal à null (Si on ne selectionne pas une catégorie), on retourne la liste des Produits
               //Sinon on retourne les produits de la categorie mentionnée (selectionnée)
               if (Category == null)
               {
                   products = productDao.Collection().ToList();
               } else
               {
                   products = productDao.Collection().Where(p => p.Category == Category).ToList();
               }

               ProductListViewModel viewModel = new ProductListViewModel();

               viewModel.Products = products;
               viewModel.Categories = categories;

               return View(viewModel);
           }
        */


        public ActionResult Index(int page = 1 , string Category = null)
        {
            
            List<Book> books;
            List<Category> categories = categoryDao.Collection().ToList();
            ViewBag.TotalPages =(int)Math.Ceiling((decimal) bookRepository.Count(Category) / MAX_BY_PAGE);
            books = bookRepository.NbPagination(page, MAX_BY_PAGE, Category);
            ViewBag.CurrentPage = page;
            
           /* if (Category == null)
            {
                products = productDao.Collection().ToList();
            }
            else
            {
                products = productDao.Collection().Where(p => p.Category == Category).ToList();
            }
           */
            BookListViewModel viewModel = new BookListViewModel();

            viewModel.Books = books;
            viewModel.Categories = categories;

            return View(viewModel);
        }

     /*   public ActionResult Details(int id)
        {
            Product product = productDao.FindById(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }
     */
    }

}





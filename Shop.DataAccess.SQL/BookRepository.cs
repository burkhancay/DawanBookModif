using Shop.Core.Models;
using Shop.DataAccess.SQL.LogicMetier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.SQL
{
    public class BookRepository : SQLRepository<Book> , IBookRepository
    {
        public BookRepository(MyContext dataContext) : base(dataContext)
        {
        }

        public int Count(string Category = null)
        {
            if(Category == null)
            {
                return DataContext.Books.AsNoTracking().Count();
            }
            else
            {
                return DataContext.Books.AsNoTracking().Where(b => b.Categorie.ToString() == Category).Count();
            }
        }
/*
        public int Search(string search)
        {
            IEnumerable<Product> lstProducts = new List<Product>();
            lstProducts = DataContext.Products.AsNoTracking().Where(p => p.)
        }
   
*/
        public List<Book> NbPagination(int page, int pagesize, string categorie)
        {
            IEnumerable<Book> result = new List<Book>();
            if(categorie == null)
            {
                result = DataContext.Books.OrderBy(x => x.Id).Skip((page - 1) * pagesize).Take(pagesize);
            }
            else
            {
                result = DataContext.Books.Where(b => b.Categorie.ToString() == categorie).OrderBy(x => x.Id).Skip((page - 1) * pagesize).Take(pagesize);
            }
            return result.ToList();
        }

       
    }

   

}

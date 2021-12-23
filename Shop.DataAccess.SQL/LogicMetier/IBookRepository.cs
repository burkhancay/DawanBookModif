using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.SQL.LogicMetier
{
    public interface IBookRepository
    {
        int Count(string Category = null);
        List<Book> NbPagination(int page, int pagesize, string categorie);
    }
}

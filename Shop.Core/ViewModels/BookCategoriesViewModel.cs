using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ViewModels
{
    public class BookCategoriesViewModel
    {
        public Book Book { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}

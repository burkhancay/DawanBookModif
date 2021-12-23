using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.WebUI.Service
{
   public  interface IBookExchangeService<T> where T : BaseEntity
    {
        void ValidateExchange(Book book, int newOwnerId);
    }
}

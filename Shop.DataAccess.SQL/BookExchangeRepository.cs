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
    public class BookExchangeRepository : IBookExchangeRepository
    {
        private MyContext db;

        public BookExchangeRepository(MyContext db)
        {
            this.db = db;
        }

        public void SaveOrUpdate(BookExchange exchange)
        {
            if (exchange.Id == null || exchange.Id == 0)
            {
                db.Entry(exchange.Book).State = EntityState.Modified;
                db.BookExchanges.Add(exchange);
            }
            else
            {
                db.Entry(exchange.Book).State = EntityState.Modified;
                db.Entry(exchange).State = EntityState.Modified;
            }

            db.SaveChanges();
        }
    }
}

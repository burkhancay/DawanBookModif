using Shop.Core.Models;
using Shop.DataAccess.SQL;
using Shop.DataAccess.SQL.LogicMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.WebUI.Service
{
    public class BookExchangeService<T> : IBookExchangeService<T> where T : BaseEntity
    {
        private IBookExchangeRepository repository;

        public void ValidateExchange(Book book, int newOwnerId)
        {
            BookExchange exc = new BookExchange { Book = book, BookId = book.Id, OldOwnerId = book.UtilisateurId };
            exc.CreationDate = DateTime.Now;
            book.UtilisateurId = newOwnerId; //On met à jour le nouveau propriétaire du livre
            book.Utilisateur = null;

            //TODO la gestion des points des utilisateurs

            repository.SaveOrUpdate(exc);
        }
    }
}

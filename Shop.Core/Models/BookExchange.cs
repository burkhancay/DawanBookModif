using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
     public class BookExchange : BaseEntity
    {
        public DateTime CreationDate { get; set; }

        [Required]
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int? BookId { get; set; }

        [ForeignKey("OldOwnerId")]
        public Utilisateur OldOwner { get; set; }
        public int? OldOwnerId { get; set; }
    }
}

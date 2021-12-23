using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
   public class Book : BaseEntity
    {
        public string Titre { get; set; }
        public string Volume { get; set; }
        [ForeignKey("CategorieId")]
        public Category Categorie { get; set; }
        public int CategorieId { get; set; }
        //[Required]
        public string Auteur { get; set; }
        public string Editeur { get; set; }
        public string DateEdition { get; set; }
       // [Required]
      //  public long ISBN { get; set; }
        public string Langue { get; set; }
        //[Required]
        public string Image { get; set; }
        public bool Disponibilite { get; set; }
        public string Description { get; set; }
        public int PointsLivre { get; set; }
        public int AvancePoints { get; set; }
        public EtatLivre EtatLivre { get; set; }
        [ForeignKey("UtilisateurId")]
        public Utilisateur Utilisateur { get; set; }
        public int UtilisateurId { get; set; }
    }
}

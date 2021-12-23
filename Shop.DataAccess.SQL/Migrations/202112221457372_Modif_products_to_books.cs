namespace Shop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modif_products_to_books : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "OwnerId", "dbo.Utilisateurs");
            DropForeignKey("dbo.BookExchanges", "ProductId", "dbo.Products");
            DropIndex("dbo.BookExchanges", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "OwnerId" });
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Volume = c.String(),
                        CategorieId = c.Int(nullable: false),
                        Auteur = c.String(nullable: false),
                        Editeur = c.String(),
                        DateEdition = c.String(),
                        ISBN = c.Long(nullable: false),
                        Langue = c.String(),
                        Image = c.String(nullable: false),
                        Disponibilite = c.Boolean(nullable: false),
                        Description = c.String(),
                        PointsLivre = c.Int(nullable: false),
                        AvancePoints = c.Int(nullable: false),
                        EtatLivre = c.Int(nullable: false),
                        UtilisateurId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategorieId, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.UtilisateurId, cascadeDelete: true)
                .Index(t => t.CategorieId)
                .Index(t => t.UtilisateurId);
            
            AddColumn("dbo.BookExchanges", "BookId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookExchanges", "BookId");
            AddForeignKey("dbo.BookExchanges", "BookId", "dbo.Books", "Id", cascadeDelete: true);
            DropColumn("dbo.BookExchanges", "ProductId");
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(),
                        Image = c.String(),
                        OwnerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BookExchanges", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BookExchanges", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "UtilisateurId", "dbo.Utilisateurs");
            DropForeignKey("dbo.Books", "CategorieId", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "UtilisateurId" });
            DropIndex("dbo.Books", new[] { "CategorieId" });
            DropIndex("dbo.BookExchanges", new[] { "BookId" });
            DropColumn("dbo.BookExchanges", "BookId");
            DropTable("dbo.Books");
            CreateIndex("dbo.Products", "OwnerId");
            CreateIndex("dbo.BookExchanges", "ProductId");
            AddForeignKey("dbo.BookExchanges", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "OwnerId", "dbo.Utilisateurs", "Id");
        }
    }
}

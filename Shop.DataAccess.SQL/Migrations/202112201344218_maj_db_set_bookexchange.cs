namespace Shop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maj_db_set_bookexchange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookExchanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                        OldOwnerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.OldOwnerId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OldOwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookExchanges", "ProductId", "dbo.Products");
            DropForeignKey("dbo.BookExchanges", "OldOwnerId", "dbo.Utilisateurs");
            DropIndex("dbo.BookExchanges", new[] { "OldOwnerId" });
            DropIndex("dbo.BookExchanges", new[] { "ProductId" });
            DropTable("dbo.BookExchanges");
        }
    }
}

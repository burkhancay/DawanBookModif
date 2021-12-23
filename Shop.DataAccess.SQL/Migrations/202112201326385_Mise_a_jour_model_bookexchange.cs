namespace Shop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mise_a_jour_model_bookexchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "OwnerId", c => c.Int());
            CreateIndex("dbo.Products", "OwnerId");
            AddForeignKey("dbo.Products", "OwnerId", "dbo.Utilisateurs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "OwnerId", "dbo.Utilisateurs");
            DropIndex("dbo.Products", new[] { "OwnerId" });
            DropColumn("dbo.Products", "OwnerId");
        }
    }
}

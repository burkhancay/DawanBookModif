namespace Shop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifBookRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Auteur", c => c.String());
            AlterColumn("dbo.Books", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Auteur", c => c.String(nullable: false));
        }
    }
}

namespace Shop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modif_ISBN : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "ISBN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "ISBN", c => c.Long(nullable: false));
        }
    }
}

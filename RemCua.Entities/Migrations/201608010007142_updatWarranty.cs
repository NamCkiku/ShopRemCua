namespace RemCua.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatWarranty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Image", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Products", "Warranty", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Warranty", c => c.Int());
            AlterColumn("dbo.Products", "Image", c => c.String(maxLength: 256));
        }
    }
}

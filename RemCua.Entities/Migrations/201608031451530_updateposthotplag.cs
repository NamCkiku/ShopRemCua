namespace RemCua.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateposthotplag : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Image", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Posts", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Content", c => c.String());
            AlterColumn("dbo.Posts", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.Posts", "Image", c => c.String(maxLength: 256));
        }
    }
}

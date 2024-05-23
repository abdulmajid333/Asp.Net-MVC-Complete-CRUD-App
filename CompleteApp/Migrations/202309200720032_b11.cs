namespace CompleteApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbluserblogs",
                c => new
                    {
                        blogid = c.Int(nullable: false, identity: true),
                        blogtitle = c.String(),
                        blogdescription = c.String(),
                    })
                .PrimaryKey(t => t.blogid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbluserblogs");
        }
    }
}

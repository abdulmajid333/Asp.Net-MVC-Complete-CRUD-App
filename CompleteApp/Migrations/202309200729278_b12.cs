namespace CompleteApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbluserblogs", "blogimage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbluserblogs", "blogimage");
        }
    }
}

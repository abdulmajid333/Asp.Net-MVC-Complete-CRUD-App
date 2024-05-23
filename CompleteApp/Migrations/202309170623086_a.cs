namespace CompleteApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblusers",
                c => new
                    {
                        userid = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        useremail = c.String(),
                        userpassword = c.String(),
                        usermobilenumber = c.Int(nullable: false),
                        userage = c.Int(nullable: false),
                        usercountry = c.Int(nullable: false),
                        userstate = c.Int(nullable: false),
                        usergender = c.Int(nullable: false),
                        userhobby = c.String(),
                        userdp = c.String(),
                    })
                .PrimaryKey(t => t.userid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblusers");
        }
    }
}

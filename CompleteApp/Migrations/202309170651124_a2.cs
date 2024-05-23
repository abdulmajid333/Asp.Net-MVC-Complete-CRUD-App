namespace CompleteApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblcountries",
                c => new
                    {
                        countryid = c.Int(nullable: false, identity: true),
                        countryname = c.String(),
                    })
                .PrimaryKey(t => t.countryid);
            
            CreateTable(
                "dbo.tblgenders",
                c => new
                    {
                        genderid = c.Int(nullable: false, identity: true),
                        gendername = c.String(),
                    })
                .PrimaryKey(t => t.genderid);
            
            CreateTable(
                "dbo.tblhobbies",
                c => new
                    {
                        hobbyid = c.Int(nullable: false, identity: true),
                        hobbyname = c.String(),
                    })
                .PrimaryKey(t => t.hobbyid);
            
            CreateTable(
                "dbo.tblstates",
                c => new
                    {
                        stateid = c.Int(nullable: false, identity: true),
                        statename = c.String(),
                        countryid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.stateid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblstates");
            DropTable("dbo.tblhobbies");
            DropTable("dbo.tblgenders");
            DropTable("dbo.tblcountries");
        }
    }
}

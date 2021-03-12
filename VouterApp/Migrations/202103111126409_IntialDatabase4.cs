namespace VouterApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDatabase4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblVouter",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        SecondName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        NationalID = c.String(nullable: false),
                        VoutingCardNo = c.String(nullable: false),
                        Region = c.String(nullable: false),
                        District = c.String(nullable: false),
                        Center = c.String(nullable: false),
                        DontatingFamily = c.String(nullable: false),
                        userid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblUser", t => t.userid, cascadeDelete: true)
                .Index(t => t.userid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblVouter", "userid", "dbo.tblUser");
            DropIndex("dbo.tblVouter", new[] { "userid" });
            DropTable("dbo.tblVouter");
        }
    }
}

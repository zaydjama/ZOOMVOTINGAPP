namespace VouterApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDatabase2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCandidate",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        SecondName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Region = c.String(nullable: false),
                        District = c.String(nullable: false),
                        Party = c.String(nullable: false),
                        Election = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblCandidate");
        }
    }
}

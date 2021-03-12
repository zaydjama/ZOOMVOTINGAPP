namespace VouterApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDatabase3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Paswd = c.String(nullable: false),
                        Roles = c.String(nullable: false),
                        Candidateid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblCandidate", t => t.Candidateid, cascadeDelete: true)
                .Index(t => t.Candidateid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUser", "Candidateid", "dbo.tblCandidate");
            DropIndex("dbo.tblUser", new[] { "Candidateid" });
            DropTable("dbo.tblUser");
        }
    }
}

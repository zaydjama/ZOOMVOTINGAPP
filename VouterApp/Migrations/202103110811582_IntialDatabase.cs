namespace VouterApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblRegion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblRegion");
        }
    }
}

namespace VouterApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDatabase1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblDistrict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistricName = c.String(nullable: false),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblRegion", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblDistrict", "RegionId", "dbo.tblRegion");
            DropIndex("dbo.tblDistrict", new[] { "RegionId" });
            DropTable("dbo.tblDistrict");
        }
    }
}

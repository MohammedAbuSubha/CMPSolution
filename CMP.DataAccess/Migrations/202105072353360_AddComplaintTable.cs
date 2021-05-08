namespace CMP.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComplaintTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Complaints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Description = c.String(),
                        IsClosedByCustomer = c.Boolean(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreateBy)
                .Index(t => t.CreateBy);
            
            CreateTable(
                "dbo.ComplaintStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComplaintId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 128),
                        CreateOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreateBy)
                .ForeignKey("dbo.Complaints", t => t.ComplaintId, cascadeDelete: true)
                .Index(t => t.ComplaintId)
                .Index(t => t.CreateBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Complaints", "CreateBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ComplaintStatus", "ComplaintId", "dbo.Complaints");
            DropForeignKey("dbo.ComplaintStatus", "CreateBy", "dbo.AspNetUsers");
            DropIndex("dbo.ComplaintStatus", new[] { "CreateBy" });
            DropIndex("dbo.ComplaintStatus", new[] { "ComplaintId" });
            DropIndex("dbo.Complaints", new[] { "CreateBy" });
            DropTable("dbo.ComplaintStatus");
            DropTable("dbo.Complaints");
        }
    }
}

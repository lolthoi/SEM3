namespace CodeFirstAndAnnotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_address_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentAddresses",
                c => new
                    {
                        StudentAddessID = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.StudentAddessID)
                .ForeignKey("dbo.Students", t => t.StudentAddessID)
                .Index(t => t.StudentAddessID);
            
            AddColumn("dbo.Students", "DoB", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAddresses", "StudentAddessID", "dbo.Students");
            DropIndex("dbo.StudentAddresses", new[] { "StudentAddessID" });
            DropColumn("dbo.Students", "DoB");
            DropTable("dbo.StudentAddresses");
        }
    }
}

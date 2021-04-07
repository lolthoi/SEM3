namespace MyAppCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        DoB = c.DateTime(),
                        Grade_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Grades", t => t.Grade_ID)
                .Index(t => t.Grade_ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Section = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CourseStudents",
                c => new
                    {
                        Course_ID = c.Int(nullable: false),
                        Student_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_ID, t.Student_ID })
                .ForeignKey("dbo.Courses", t => t.Course_ID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_ID, cascadeDelete: true)
                .Index(t => t.Course_ID)
                .Index(t => t.Student_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Grade_ID", "dbo.Grades");
            DropForeignKey("dbo.CourseStudents", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.CourseStudents", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.Addresses", "ID", "dbo.Students");
            DropIndex("dbo.CourseStudents", new[] { "Student_ID" });
            DropIndex("dbo.CourseStudents", new[] { "Course_ID" });
            DropIndex("dbo.Students", new[] { "Grade_ID" });
            DropIndex("dbo.Addresses", new[] { "ID" });
            DropTable("dbo.CourseStudents");
            DropTable("dbo.Grades");
            DropTable("dbo.Courses");
            DropTable("dbo.Students");
            DropTable("dbo.Addresses");
        }
    }
}

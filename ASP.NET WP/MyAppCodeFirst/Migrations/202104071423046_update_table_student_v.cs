namespace MyAppCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_student_v : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Admin.StudentInfo", "StudentClass_ID", "dbo.StudentClasses");
            DropForeignKey("Admin.StudentInfo", "StudentClass_ID1", "dbo.StudentClasses");
            DropForeignKey("dbo.StudentClasses", "Student_ID", "Admin.StudentInfo");
            DropIndex("Admin.StudentInfo", new[] { "StudentClass_ID" });
            DropIndex("Admin.StudentInfo", new[] { "StudentClass_ID1" });
            DropIndex("dbo.StudentClasses", new[] { "Student_ID" });
            CreateTable(
                "dbo.StudentClassStudents",
                c => new
                    {
                        StudentClass_ID = c.Int(nullable: false),
                        Student_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentClass_ID, t.Student_ID })
                .ForeignKey("dbo.StudentClasses", t => t.StudentClass_ID, cascadeDelete: true)
                .ForeignKey("Admin.StudentInfo", t => t.Student_ID, cascadeDelete: true)
                .Index(t => t.StudentClass_ID)
                .Index(t => t.Student_ID);
            
            DropColumn("Admin.StudentInfo", "StudentClass_ID");
            DropColumn("Admin.StudentInfo", "StudentClass_ID1");
            DropColumn("dbo.StudentClasses", "Student_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentClasses", "Student_ID", c => c.Int());
            AddColumn("Admin.StudentInfo", "StudentClass_ID1", c => c.Int());
            AddColumn("Admin.StudentInfo", "StudentClass_ID", c => c.Int());
            DropForeignKey("dbo.StudentClassStudents", "Student_ID", "Admin.StudentInfo");
            DropForeignKey("dbo.StudentClassStudents", "StudentClass_ID", "dbo.StudentClasses");
            DropIndex("dbo.StudentClassStudents", new[] { "Student_ID" });
            DropIndex("dbo.StudentClassStudents", new[] { "StudentClass_ID" });
            DropTable("dbo.StudentClassStudents");
            CreateIndex("dbo.StudentClasses", "Student_ID");
            CreateIndex("Admin.StudentInfo", "StudentClass_ID1");
            CreateIndex("Admin.StudentInfo", "StudentClass_ID");
            AddForeignKey("dbo.StudentClasses", "Student_ID", "Admin.StudentInfo", "ID");
            AddForeignKey("Admin.StudentInfo", "StudentClass_ID1", "dbo.StudentClasses", "ID");
            AddForeignKey("Admin.StudentInfo", "StudentClass_ID", "dbo.StudentClasses", "ID");
        }
    }
}

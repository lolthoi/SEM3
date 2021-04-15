namespace MyAppCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_student_v6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Admin.StudentInfo", t => t.Student_ID)
                .Index(t => t.Student_ID);
            
            AddColumn("Admin.StudentInfo", "StudentClass_ID", c => c.Int());
            AddColumn("Admin.StudentInfo", "StudentClass_ID1", c => c.Int());
            CreateIndex("Admin.StudentInfo", "StudentClass_ID");
            CreateIndex("Admin.StudentInfo", "StudentClass_ID1");
            AddForeignKey("Admin.StudentInfo", "StudentClass_ID", "dbo.StudentClasses", "ID");
            AddForeignKey("Admin.StudentInfo", "StudentClass_ID1", "dbo.StudentClasses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentClasses", "Student_ID", "Admin.StudentInfo");
            DropForeignKey("Admin.StudentInfo", "StudentClass_ID1", "dbo.StudentClasses");
            DropForeignKey("Admin.StudentInfo", "StudentClass_ID", "dbo.StudentClasses");
            DropIndex("dbo.StudentClasses", new[] { "Student_ID" });
            DropIndex("Admin.StudentInfo", new[] { "StudentClass_ID1" });
            DropIndex("Admin.StudentInfo", new[] { "StudentClass_ID" });
            DropColumn("Admin.StudentInfo", "StudentClass_ID1");
            DropColumn("Admin.StudentInfo", "StudentClass_ID");
            DropTable("dbo.StudentClasses");
        }
    }
}

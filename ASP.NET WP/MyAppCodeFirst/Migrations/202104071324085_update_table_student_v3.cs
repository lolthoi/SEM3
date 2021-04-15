namespace MyAppCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_student_v3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Students", newName: "StudentInfo");
            MoveTable(name: "dbo.StudentInfo", newSchema: "Admin");
        }
        
        public override void Down()
        {
            MoveTable(name: "Admin.StudentInfo", newSchema: "dbo");
            RenameTable(name: "dbo.StudentInfo", newName: "Students");
        }
    }
}

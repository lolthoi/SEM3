namespace MyAppCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_student_v4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "Admin.StudentInfo", name: "DoB", newName: "Date of birth");
        }
        
        public override void Down()
        {
            RenameColumn(table: "Admin.StudentInfo", name: "Date of birth", newName: "DoB");
        }
    }
}

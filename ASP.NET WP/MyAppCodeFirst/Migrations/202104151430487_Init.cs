namespace MyAppCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer_Payment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Customer_Id = c.Int(nullable: false),
                        Payment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Payments", t => t.Payment_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Payment_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Customer_ID = c.Int(nullable: false, identity: true),
                        Customer_FirstName = c.String(nullable: false),
                        Customer_LastName = c.String(nullable: false),
                        Customer_Phone = c.String(nullable: false),
                        Customer_Email = c.String(nullable: false),
                        Customer_Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Customer_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Order_ID = c.Int(nullable: false, identity: true),
                        Order_Status = c.String(nullable: false),
                        Order_Date = c.DateTime(nullable: false),
                        Staff_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Order_ID)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.Staff_Id, cascadeDelete: true)
                .Index(t => t.Staff_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Order_Material",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Order_Id = c.Int(nullable: false),
                        Material_Id = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Materials", t => t.Material_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Material_Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Material_ID = c.Int(nullable: false, identity: true),
                        Material_Description = c.String(nullable: false),
                        Material_Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Material_ID);
            
            CreateTable(
                "dbo.Order_Size",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Order_Id = c.Int(nullable: false),
                        Size_Id = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sizes", t => t.Size_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Size_Id);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Size_ID = c.Int(nullable: false, identity: true),
                        Size_Description = c.String(nullable: false),
                        Size_Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Size_ID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Staff_ID = c.Int(nullable: false, identity: true),
                        Staff_FirstName = c.String(nullable: false),
                        Staff_LastName = c.String(nullable: false),
                        Staff_Phone = c.String(nullable: false),
                        Staff_Email = c.String(nullable: false),
                        Staff_Roles = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Staff_ID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Payment_ID = c.Int(nullable: false, identity: true),
                        Payment_Method = c.String(nullable: false),
                        Payment_Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Payment_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer_Payment", "Payment_Id", "dbo.Payments");
            DropForeignKey("dbo.Orders", "Staff_Id", "dbo.Staffs");
            DropForeignKey("dbo.Order_Size", "Size_Id", "dbo.Sizes");
            DropForeignKey("dbo.Order_Size", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Order_Material", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Order_Material", "Material_Id", "dbo.Materials");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Customer_Payment", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Order_Size", new[] { "Size_Id" });
            DropIndex("dbo.Order_Size", new[] { "Order_Id" });
            DropIndex("dbo.Order_Material", new[] { "Material_Id" });
            DropIndex("dbo.Order_Material", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.Orders", new[] { "Staff_Id" });
            DropIndex("dbo.Customer_Payment", new[] { "Payment_Id" });
            DropIndex("dbo.Customer_Payment", new[] { "Customer_Id" });
            DropTable("dbo.Payments");
            DropTable("dbo.Staffs");
            DropTable("dbo.Sizes");
            DropTable("dbo.Order_Size");
            DropTable("dbo.Materials");
            DropTable("dbo.Order_Material");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Customer_Payment");
        }
    }
}

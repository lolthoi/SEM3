namespace DBFirstAndLINQ2SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "sales.customers",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false, maxLength: 255, unicode: false),
                        last_name = c.String(nullable: false, maxLength: 255, unicode: false),
                        phone = c.String(maxLength: 25, unicode: false),
                        email = c.String(nullable: false, maxLength: 255, unicode: false),
                        street = c.String(maxLength: 255, unicode: false),
                        city = c.String(maxLength: 50, unicode: false),
                        state = c.String(maxLength: 25, unicode: false),
                        zip_code = c.String(maxLength: 5, unicode: false),
                    })
                .PrimaryKey(t => t.customer_id);
            
            CreateTable(
                "sales.orders",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        customer_id = c.Int(),
                        order_status = c.Byte(nullable: false),
                        order_date = c.DateTime(nullable: false, storeType: "date"),
                        required_date = c.DateTime(nullable: false, storeType: "date"),
                        shipped_date = c.DateTime(storeType: "date"),
                        store_id = c.Int(nullable: false),
                        staff_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("sales.staffs", t => t.staff_id)
                .ForeignKey("sales.stores", t => t.store_id, cascadeDelete: true)
                .ForeignKey("sales.customers", t => t.customer_id, cascadeDelete: true)
                .Index(t => t.customer_id)
                .Index(t => t.store_id)
                .Index(t => t.staff_id);
            
            CreateTable(
                "sales.order_items",
                c => new
                    {
                        order_id = c.Int(nullable: false),
                        item_id = c.Int(nullable: false),
                        product_id = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        list_price = c.Decimal(nullable: false, precision: 10, scale: 2),
                        discount = c.Decimal(nullable: false, precision: 4, scale: 2),
                    })
                .PrimaryKey(t => new { t.order_id, t.item_id })
                .ForeignKey("sales.orders", t => t.order_id, cascadeDelete: true)
                .ForeignKey("production.products", t => t.product_id, cascadeDelete: true)
                .Index(t => t.order_id)
                .Index(t => t.product_id);
            
            CreateTable(
                "production.products",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        product_name = c.String(nullable: false, maxLength: 255, unicode: false),
                        brand_id = c.Int(nullable: false),
                        category_id = c.Int(nullable: false),
                        model_year = c.Short(nullable: false),
                        list_price = c.Decimal(nullable: false, precision: 10, scale: 2),
                    })
                .PrimaryKey(t => t.product_id);
            
            CreateTable(
                "sales.staffs",
                c => new
                    {
                        staff_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false, maxLength: 50, unicode: false),
                        last_name = c.String(nullable: false, maxLength: 50, unicode: false),
                        email = c.String(nullable: false, maxLength: 255, unicode: false),
                        phone = c.String(maxLength: 25, unicode: false),
                        active = c.Byte(nullable: false),
                        store_id = c.Int(nullable: false),
                        manager_id = c.Int(),
                    })
                .PrimaryKey(t => t.staff_id)
                .ForeignKey("sales.staffs", t => t.manager_id)
                .ForeignKey("sales.stores", t => t.store_id, cascadeDelete: true)
                .Index(t => t.store_id)
                .Index(t => t.manager_id);
            
            CreateTable(
                "sales.stores",
                c => new
                    {
                        store_id = c.Int(nullable: false, identity: true),
                        store_name = c.String(nullable: false, maxLength: 255, unicode: false),
                        phone = c.String(maxLength: 25, unicode: false),
                        email = c.String(maxLength: 255, unicode: false),
                        street = c.String(maxLength: 255, unicode: false),
                        city = c.String(maxLength: 255, unicode: false),
                        state = c.String(maxLength: 10, unicode: false),
                        zip_code = c.String(maxLength: 5, unicode: false),
                    })
                .PrimaryKey(t => t.store_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("sales.orders", "customer_id", "sales.customers");
            DropForeignKey("sales.staffs", "store_id", "sales.stores");
            DropForeignKey("sales.orders", "store_id", "sales.stores");
            DropForeignKey("sales.staffs", "manager_id", "sales.staffs");
            DropForeignKey("sales.orders", "staff_id", "sales.staffs");
            DropForeignKey("sales.order_items", "product_id", "production.products");
            DropForeignKey("sales.order_items", "order_id", "sales.orders");
            DropIndex("sales.staffs", new[] { "manager_id" });
            DropIndex("sales.staffs", new[] { "store_id" });
            DropIndex("sales.order_items", new[] { "product_id" });
            DropIndex("sales.order_items", new[] { "order_id" });
            DropIndex("sales.orders", new[] { "staff_id" });
            DropIndex("sales.orders", new[] { "store_id" });
            DropIndex("sales.orders", new[] { "customer_id" });
            DropTable("sales.stores");
            DropTable("sales.staffs");
            DropTable("production.products");
            DropTable("sales.order_items");
            DropTable("sales.orders");
            DropTable("sales.customers");
        }
    }
}

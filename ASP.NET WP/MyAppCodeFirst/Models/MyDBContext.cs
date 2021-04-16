using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyAppCodeFirst.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("name=MyAppCodeFirst")
        {
            //Database.SetInitializer<MyDBContext>(new MyDBInit());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new StudentConfig());
        }
        public DbSet<Customer_Payment> Customer_Payment { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order_Material> Order_Material { get; set; }
        public DbSet<Order_Size> Order_Size { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
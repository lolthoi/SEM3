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
            modelBuilder.Configurations.Add(new StudentConfig());
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
    }
}
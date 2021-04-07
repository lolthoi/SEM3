using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstAndAnnotation.Models
{
    public class CodeFirstAnnotationContext : DbContext
    {
        public CodeFirstAnnotationContext() : base("MyDatabase")
        {
            Database.SetInitializer<CodeFirstAnnotationContext>(new CodeFirstAnnotationInit());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentConfigurations());
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
    }
}
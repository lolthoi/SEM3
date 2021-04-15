using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MyAppCodeFirst.Models
{
    public class MyDBInit : CreateDatabaseIfNotExists<MyDBContext>
    {
        protected override void Seed(MyDBContext context)
        {
            IList<Grade> grades = new List<Grade>();
            grades.Add(new Grade() { Title = "G1", Section = "A" });
            grades.Add(new Grade() { Title = "G2", Section = "B" });
            grades.Add(new Grade() { Title = "G3", Section = "C" });
            context.Grades.AddRange(grades);
            base.Seed(context);
        }
    }
}
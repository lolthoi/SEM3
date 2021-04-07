using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CodeFirstAndAnnotation.Models
{
    public class CodeFirstAnnotationInit : DropCreateDatabaseAlways<CodeFirstAnnotationContext>
    {
        protected override void Seed(CodeFirstAnnotationContext context)
        {
            IList<Grade> grades = new List<Grade>();
            grades.Add(new Grade() { GradeName = "G1", Section = "A" });
            grades.Add(new Grade() { GradeName = "G2", Section = "B" });
            grades.Add(new Grade() { GradeName = "G3", Section = "C" });
            context.Grades.AddRange(grades);
            base.Seed(context);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace MyAppCodeFirst.Models
{
    public class StudentConfig : EntityTypeConfiguration<Student>
    {
        public StudentConfig()
        {
            //Cấu hình quan hệ 1 - 1 trong database
            this.HasOptional(s => s.Address) //HasOptional : có thể để trống
                .WithRequired(sd => sd.Student); // WithRequired : bắt buộc phải có 
        }
    }
}
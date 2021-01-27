using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string CoverImage { get; set; }
    }
    public class BookManager
    {
        public static List<Book> GetBooks()
        {
            var books = new List<Book>();
            books.Add(new Book { BookId = 1, Title = "lap trinh c sharp 1", Author = "Bill Gate", CoverImage = "Assets/1.png" });
            books.Add(new Book { BookId = 2, Title = "lap trinh c sharp 2", Author = "Bill Gate", CoverImage = "Assets/2.png" });
            books.Add(new Book { BookId = 3, Title = "lap trinh c sharp 3", Author = "Bill Gate", CoverImage = "Assets/3.png" });
            books.Add(new Book { BookId = 4, Title = "lap trinh c sharp 4", Author = "Bill Gate", CoverImage = "Assets/4.png" });
            books.Add(new Book { BookId = 5, Title = "lap trinh c sharp 5", Author = "Bill Gate", CoverImage = "Assets/5.png" });
            books.Add(new Book { BookId = 6, Title = "lap trinh c sharp 6", Author = "Bill Gate", CoverImage = "Assets/6.png" });
            books.Add(new Book { BookId = 7, Title = "lap trinh c sharp 7", Author = "Bill Gate", CoverImage = "Assets/7.png" });
            books.Add(new Book { BookId = 8, Title = "lap trinh c sharp 8", Author = "Bill Gate", CoverImage = "Assets/8.png" });
            books.Add(new Book { BookId = 9, Title = "lap trinh c sharp 9", Author = "Bill Gate", CoverImage = "Assets/9.png" });
            books.Add(new Book { BookId = 10, Title = "lap trinh c sharp 10", Author = "Bill Gate", CoverImage = "Assets/10.png" });
            books.Add(new Book { BookId = 11, Title = "lap trinh c sharp 11", Author = "Bill Gate", CoverImage = "Assets/11.png" });
            books.Add(new Book { BookId = 12, Title = "lap trinh c sharp 12", Author = "Bill Gate", CoverImage = "Assets/12.png" });
            books.Add(new Book { BookId = 13, Title = "lap trinh c sharp 13", Author = "Bill Gate", CoverImage = "Assets/13.png" });

            return books;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Model
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string HeadLine { get; set; }
        public string SubHead { get; set; }
        public string DateLine { get; set; }
        public string Image { get; set; }
    }

    public class NewsManager
    {
        public static void GetNews(string category, ObservableCollection<NewsItem> newsItems)
        {
            var allItems = getNewsItems();
            var filteredNewsItems = allItems.Where(p => p.Category == category).ToList();
            newsItems.Clear();
            filteredNewsItems.ForEach(p => newsItems.Add(p));
        }

        public static List<NewsItem> getNewsItems()
        {
            var items = new List<NewsItem>();

            items.Add(new NewsItem() { Id = 1, Category = "Food", HeadLine = "Food News head line 01", SubHead = "food news subhead 01", DateLine = "food news DateLine 01", Image = "Assets/Food1.png" });
            items.Add(new NewsItem() { Id = 2, Category = "Food", HeadLine = "Food News head line 02", SubHead = "food news subhead 02", DateLine = "food news DateLine 02", Image = "Assets/Food2.png" });
            items.Add(new NewsItem() { Id = 3, Category = "Food", HeadLine = "Food News head line 03", SubHead = "food news subhead 03", DateLine = "food news DateLine 03", Image = "Assets/Food3.png" });
            items.Add(new NewsItem() { Id = 4, Category = "Food", HeadLine = "Food News head line 04", SubHead = "food news subhead 04", DateLine = "food news DateLine 04", Image = "Assets/Food4.png" });
            items.Add(new NewsItem() { Id = 5, Category = "Food", HeadLine = "Food News head line 05", SubHead = "food news subhead 05", DateLine = "food news DateLine 05", Image = "Assets/Food5.png" });
            items.Add(new NewsItem() { Id = 6, Category = "Financial", HeadLine = "Financial News Head Line 01", SubHead = "Financial News subhead 01", DateLine = "Financial news DateLine 01", Image = "Assets/Financial2.png" });
            items.Add(new NewsItem() { Id = 7, Category = "Financial", HeadLine = "Financial News Head Line 02", SubHead = "Financial News subhead 02", DateLine = "Financial news DateLine 02", Image = "Assets/Financial3.png" });
            items.Add(new NewsItem() { Id = 8, Category = "Financial", HeadLine = "Financial News Head Line 03", SubHead = "Financial News subhead 03", DateLine = "Financial news DateLine 03", Image = "Assets/Financial4.png" });
            items.Add(new NewsItem() { Id = 9, Category = "Financial", HeadLine = "Financial News Head Line 04", SubHead = "Financial News subhead 04", DateLine = "Financial news DateLine 04", Image = "Assets/Financial5.png" });

            return items;
        }
    }
}

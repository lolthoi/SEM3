using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NewsAPI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Article> Articles;
        public MainPage()
        {
            this.InitializeComponent();
            Articles = new ObservableCollection<Article>();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            if (Articles != null)
            {
                Articles.Clear();
            }
            var result = textSearch.Text;
            CallApi(result);
        }

        public async void CallApi(string q)
        {
            var url = String.Format("http://newsapi.org/v2/everything?q={0}&from=2021-02-19&sortBy=publishedAt&apiKey=dbf1b99c9ba741679e891bf4104b3f21", q);
            var news = (Root)await NewsAPI.GetNews(url);
            news.articles.ForEach(n =>
            {
                Articles.Add(n);
            });

        }

        private void NewsItemGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            Article ar = e.ClickedItem as Article;
            Frame.Navigate(typeof(ArticleView), ar);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

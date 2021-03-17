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
            CallApi("tesla", "2021-02-15", "publishedAt", "edaf13ccfa1a443085c925ff3792edd9");
        }

        public async void CallApi(string q, string from, string sortBy, string apikey)
        {
            var url = String.Format("http://newsapi.org/v2/everything?q={0}&from={1}&sortBy={2}&apiKey={3}", q, from, sortBy, apikey);
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
    }
}

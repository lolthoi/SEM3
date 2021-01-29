using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using lab3.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace lab3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<NewsItem> NewsItems;

        public MainPage()
        {
            this.InitializeComponent();
            NewsItems = new ObservableCollection<NewsItem>();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Splitview1.IsPaneOpen = !Splitview1.IsPaneOpen;
        }

        private void listbox_selectionchanged(object sender, SelectionChangedEventArgs e)
        {
            if (Financial.IsSelected)
            {
                NewsManager.GetNews("Financial", NewsItems);
                TitleTextBlock.Text = "Financial";
            }
            else if (Food.IsSelected)
            {
                NewsManager.GetNews("Food", NewsItems);
                TitleTextBlock.Text = "Food";
            }
        }
        private void Page_loader(object sender, RoutedEventArgs e)
        {
            Financial.IsSelected = true;
        }
    }
}

using SQLite.Net.Attributes;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Exam
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string path;
        SQLite.Net.SQLiteConnection conn;

        public MainPage()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "database.sqlite");
            conn = new SQLite.Net.SQLiteConnection
                (new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<Contact>();
        }

        public class Contact
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Name { get; set; }
            [Unique]
            public string Phone { get; set; }
        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            var query1 = conn.Table<Contact>();
            var addphone = addPhoneText.Text;
            var flag = 0;
            foreach (var ct in query1)
            {
                if (addphone.Equals(ct.Phone))
                {
                    message.Text = "So dien thoai da bi trung";
                    flag = 1;
                    break;
                }
            }
            if (flag == 0)
            {
                var contact = conn.Insert(new Contact()
                {
                    Name = addNameText.Text,
                    Phone = addphone,
                });
            }
        }

        private void SeachContact_Click(object sender, RoutedEventArgs e)
        {
            var query = conn.Table<Contact>();
            string name = searchNameText.Text;
            string phone = "";
            foreach (var message in query)
            {
                if (name == message.Name)
                {
                    phone = phone + "" + message.Phone;
                    searchResult.Text = "\nName: " + name + "\nPhone: " + phone;
                    break;
                }
                else
                {
                    searchResult.Text = "Contact not found";
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for CompanyInformation.xaml
    /// </summary>
    
    public partial class CompanyInformation : Window
    {
        int Role = 0;
        public CompanyInformation(int Role)
        {
            InitializeComponent();
            if (Role == 14)
            {
                ListViewItem item = new ListViewItem();
                item.Content = "Sellers";
                Options_List.Items.Add(item);

            }

            if (Role == 15)
            {
                 ListViewItem item = new ListViewItem();
                 item.Content= "Sellers";
                 ListViewItem item1 = new ListViewItem();
                item1.Content = "Users";
                Options_List.Items.Add(item);
                Options_List.Items.Add(item1);

            }
        }
       

        private void Books_Item_Selected(object sender, RoutedEventArgs e)
        {

        }

        public void Set_Role(int Role)
        {
            this.Role = Role;
        }

        private void Options_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected_item="";
            foreach (ListViewItem item in Options_List.SelectedItems)
            {
               selected_item = (item.Content).ToString();
            }
            if (selected_item.Equals("Books"))
            {
                DataGridTextColumn name = new DataGridTextColumn();
                name.Header = "Name";
                name.Binding = new Binding("Name");
                name.Width = 80;
                DataGridTextColumn description = new DataGridTextColumn();
                description.Header = "Description";
                description.Binding = new Binding("Description");
                var style = new Style();
                style.Setters.Add(new EventSetter(Hyperlink.ClickEvent, (RoutedEventHandler)EventSetter_OnHandler));
                DataGridHyperlinkColumn website = new DataGridHyperlinkColumn();
                website.Header = "Website";
                website.Binding = new Binding("Website");
                website.ElementStyle = style;
                Results_level1.Columns.Add(name);
                Results_level1.Columns.Add(description);
                Results_level1.Columns.Add(website);
                Results_level1.Items.Add(new Books() { Name = "Book 1", Description = "Desc", Website = "www.google.com" });
            }
            
        }

        private void Logout_Btn_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Hide();
        }

        private void Results_level1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        void EventSetter_OnHandler(object sender, RoutedEventArgs e)
        {
            var destination = ((Hyperlink)e.OriginalSource).NavigateUri;
            Process.Start(destination.ToString());
        }

        
    }

    public class Books
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
    }

    public class Contacts
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Users
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }

    public class Used_BookSellers
    {
        public string Name { get; set; }
        public string Email { get; set; }

    }

    public class Used_Books
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public DatePicker Current_date { get; set; }
    }

    public class Used_Books_Seller
    {
        public string Name { get; set; }
        public TextBox Price { get; set; }
        public DatePicker Current_date { get; set; }

    }
}

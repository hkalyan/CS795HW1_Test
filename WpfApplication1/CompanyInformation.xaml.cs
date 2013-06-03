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
                Results_level1.Columns.Clear();
                Results_level1.Items.Clear();
                SetBooksData();
            }
            else if (selected_item.Equals("Users"))
            {
                Results_level1.Columns.Clear();
                Results_level1.Items.Clear();
                SetUsersData();
            }
            else if (selected_item.Equals("Contact Us"))
            {
                Results_level1.Columns.Clear();
                Results_level1.Items.Clear();
                SetContactsData();
            }
            
        }

        private void SetContactsData()
        {
            DataGridTextColumn name = new DataGridTextColumn();
            name.Header = "Name";
            name.Binding = new Binding("Name");
            DataGridTextColumn email = new DataGridTextColumn();
            email.Header = "Email";
            email.Binding = new Binding("Email");
            Results_level1.Columns.Add(name);
            Results_level1.Columns.Add(email);
            Results_level1.Items.Add(new Contacts() { Name = "Hari Phaneendra", Email = "hkalyan@cs.odu.edu" });
            Results_level1.Items.Add(new Contacts() { Name = "Ravi Mukkamala", Email = "rmukka@cs.odu.edu" });
        }

        private void SetUsersData()
        {
            DataGridTextColumn name = new DataGridTextColumn();
            name.Header = "Name";
            name.Binding = new Binding("Name");
            DataGridTextColumn role = new DataGridTextColumn();
            role.Header = "Role";
            role.Binding = new Binding("Role");
            Results_level1.Columns.Add(name);
            Results_level1.Columns.Add(role);
            Results_level1.Items.Add(new Users() { Name = "hkalyan" , Role = "Browser"});
            Results_level1.Items.Add(new Users() { Name = "mukka", Role = "Admin" });
            Results_level1.Items.Add(new Users() { Name = "seller", Role = "Seller" });
            Results_level1.Items.Add(new Users() { Name = "browser", Role = "Browser" });
            Results_level1.Items.Add(new Users() { Name = "buyer", Role = "Buyer" });
        }

        private void SetBooksData()
        {
            DataGridTextColumn name = new DataGridTextColumn();
            name.Header = "Name";
            name.Binding = new Binding("Name");
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
            Results_level1.Items.Add(new Books() { Name = "Python Programming: An Introduction to Computer Science 2nd Edition", Description = "This is the second edition of John Zelle's Python Programming, updated for Python 3. This book is designed to be used as the primary textbook in a college-level first course in computing. It takes a fairly traditional approach, emphasizing problem solving, design, and programming as the core skills of computer science. However, these ideas are illustrated using a non-traditional language, namely Python.", Website = "https://www.fbeedle.com/" });
            Results_level1.Items.Add(new Books() { Name = "Computer Systems: A Programmer's Perspective", Description = "For Computer Organization and Architecture and Computer Systems courses in CS and EE and ECE departments. Developed out of an introductory course at Carnegie Mellon University, this text explains the important and enduring concepts underlying all computer systems, and shows the concrete ways that these ideas affect the correctness, performance, and utility of application programs. The text's concrete and hands-on approach will help students understand what is going on under the hood of a computer system.", Website = "http://prenticehall.com/" });
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

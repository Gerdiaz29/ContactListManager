using ContactListManager.Model;
using System.Windows;
using System.Windows.Controls;

namespace ContactListManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            

            var contact = new Contact
            {
                FirstName = "Gerardo",
                LastName = "Diaz",
                City = "Orlando",
                Email = "gerardoadh_90@hotmail.com",
                PhoneNumber = "3863019507",
                PhoneType = PhoneTypes.Mobile,
                PostalCode = 32824,
                State = "Florida",
                StreetAddress = "14756 Huntcliff Park Way"
            };
            ContactsStorage.AddContact(contact);
            dg_Contacts.ItemsSource = ContactsStorage.GetContacts();

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            dg_Contacts.ItemsSource = ContactsStorage.GetContacts();
        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            AddContact addContact = new AddContact();

            addContact.Show();
        }
    }
}

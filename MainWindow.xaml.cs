using ContactListManager.Enums;
using ContactListManager.Models;
using ContactListManager.Storages;
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
                PostalCode = "32824",
                State = "Florida",
                StreetAddress = "14756 Huntcliff Park Way"
            };
            ContactsStorage.AddContact(contact);
            dg_Contacts.ItemsSource = ContactsStorage.GetContacts();

        }

        public void RefreshGrid()
        {
            dg_Contacts.ItemsSource = ContactsStorage.GetContacts();
        }

        private void btn_AddContact_Click(object sender, RoutedEventArgs e)
        {
            AddContact addContact = new AddContact(this);

            addContact.Show();
        }
        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            btn_Edit.Visibility = Visibility.Visible;
            btn_Delete.Visibility = Visibility.Visible;


        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            var contact = (Contact)dg_Contacts.SelectedItem;

            AddContact addContact = new AddContact(this, contact);

            addContact.Show();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            var contact = (Contact)dg_Contacts.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Are you sure you want to deleted this contact?", "Delete Contact", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                ContactsStorage.DeleteContact(contact);
                RefreshGrid();
            }
        }
    }
}
using ContactListManager.Model;
using System;
using System.Linq;
using System.Windows;

namespace ContactListManager
{
    /// <summary>
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        public AddContact()
        {
            InitializeComponent();
            cb_PhoneType.ItemsSource = Enum.GetValues(typeof(PhoneTypes)).Cast<PhoneTypes>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Email = tb_Email.Text,
                PhoneNumber = tb_PhoneNumber.Text,
                PhoneType = (PhoneTypes)cb_PhoneType.SelectedValue,
                City = tb_City.Text,
                State = tb_State.Text,
                StreetAddress = tb_StreetAddress.Text,
                PostalCode = int.Parse(tb_PostalCode.Text)
            };

            ContactsStorage.AddContact(contact);
            MessageBox.Show($"{contact.FirstName} contact has been created", "Contact Created");
            
        }
    }
}

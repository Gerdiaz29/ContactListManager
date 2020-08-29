using ContactListManager.Enums;
using ContactListManager.Models;
using ContactListManager.Storages;
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
        private MainWindow _mainWindow;
        private Contact _contact;
        private bool _isEdit;
        public AddContact(MainWindow mainWindow, Contact contact = null, bool isEdit = false)
        {

            InitializeComponent();
            _mainWindow = mainWindow;
            cb_PhoneType.ItemsSource = Enum.GetValues(typeof(PhoneTypes)).Cast<PhoneTypes>();
            _contact = contact ?? new Contact();
            this.DataContext = _contact;
            _isEdit = isEdit;
            if (isEdit)
            {
                this.Title = "Edit Contact";
            }
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {

            bool hasError = false;

            if (string.IsNullOrWhiteSpace(tb_FirstName.Text))
            {
                MessageBox.Show("First Name Field is Required");
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(tb_LastName.Text))
            {
                MessageBox.Show("Last Name Field is Required");
                hasError = true;

            }

            if (string.IsNullOrWhiteSpace(tb_Email.Text))
            {
                MessageBox.Show("Email Field is Required");
                hasError = true;
            }

            if (!hasError)
            {
                if (_isEdit)
                {
                    ContactsStorage.EditContact(_contact);
                    MessageBox.Show($"{_contact.FirstName} contact has been modified", "Contact Created");

                }
                else
                {
                    ContactsStorage.AddContact(_contact);
                    MessageBox.Show($"{_contact.FirstName} contact has been created", "Contact Created");

                }

                _mainWindow.RefreshGrid();

                this.Close();
            }
        }
    }
}

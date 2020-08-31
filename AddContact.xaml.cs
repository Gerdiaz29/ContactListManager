using ContactListManager.Enums;
using ContactListManager.Models;
using ContactListManager.Storages;
using ContactListManager.ViewModels;
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
        private ContactViewModel _contact;
        private bool _isEdit;
        public AddContact(MainWindow mainWindow, ContactViewModel contact = null, bool isEdit = false)
        {

            InitializeComponent();
            _isEdit = isEdit;
            _mainWindow = mainWindow;

            cb_PhoneType.ItemsSource = Enum.GetValues(typeof(PhoneTypes)).Cast<PhoneTypes>();
            _contact = contact ?? new ContactViewModel();
            this.DataContext = _contact;
            if (_isEdit)
            {
                this.Title = $"Edit contact {contact.FirstName} (#{contact.Id})";
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

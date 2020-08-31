using ContactListManager.Enums;
using ContactListManager.Storages;
using ContactListManager.Utils;
using ContactListManager.ViewModels;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

            var contact = new ContactViewModel
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
            var contact = (ContactViewModel)dg_Contacts.SelectedItem;

            AddContact addContact = new AddContact(this, contact, true);

            addContact.Show();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            var contact = (ContactViewModel)dg_Contacts.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Are you sure you want to deleted this contact?", "Delete Contact", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                ContactsStorage.DeleteContact(contact);
                RefreshGrid();
            }
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            var contacts = ContactsStorage.GetContacts();

            var xmlfile = new Serialize().ToXML(contacts);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML file (*.xml)|*.xml";

            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, xmlfile);
            }
        }

        private void MenuLoad_Click(object sender, RoutedEventArgs e)
        {
            var xmlContacts = "";
            var contacts = new List<ContactViewModel>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML file (*.xml)|*.xml";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                xmlContacts = File.ReadAllText(openFileDialog.FileName);
                contacts = Serialize.FromXML<List<ContactViewModel>>(xmlContacts);

                foreach (var contact in contacts)
                {
                    ContactsStorage.AddContact(contact);
                }

                RefreshGrid();
            }
        }        

        private void dg_Contacts_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var pd = (PropertyDescriptor)e.PropertyDescriptor;
            var atb = (DisplayAttribute)pd.Attributes[typeof(DisplayAttribute)];
            if (atb != null)
            {
                e.Column.Header = atb.Name;
            }
        }
    }
}
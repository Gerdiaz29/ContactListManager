using ContactListManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactListManager.Storages
{
    public static class ContactsStorage
    {

        private static List<Contact> _contacts = new List<Contact>();

        public static List<Contact> GetContacts()
        {
            return _contacts.Where(c => !c.IsDeleted).Select(c => c.Clone()).ToList();
        }

        public static void AddContact(Contact contact)
        {
            var newContact = contact.Clone();
            newContact.Id = (_contacts?.Max(c => c.Id) ?? 0) + 1;

            _contacts.Add(newContact.Clone());
        }

        internal static void EditContact(Contact contact)
        {
            if (contact != null)
            {
                var contactToEdit = _contacts.FirstOrDefault(c => c.Id == contact.Id && !c.IsDeleted);

                if (contactToEdit != null)
                {
                    contactToEdit.FirstName = contact.FirstName;
                    contactToEdit.LastName = contact.LastName;
                    contactToEdit.Email = contact.Email;
                    contactToEdit.PhoneNumber = contact.PhoneNumber;
                    contactToEdit.PhoneType = contact.PhoneType;
                    contactToEdit.City = contact.City;
                    contactToEdit.State = contact.State;
                    contactToEdit.StreetAddress = contact.StreetAddress;
                    contactToEdit.PostalCode = contact.PostalCode;
                }
            }
        }

        internal static void DeleteContact(Contact contact)
        {
            if (contact != null)
            {
                var contactToDelete = _contacts.FirstOrDefault(c => c.Id == contact.Id && !c.IsDeleted);

                if (contactToDelete != null)
                {
                    contactToDelete.IsDeleted = true;
                }
            }
        }
    }
}

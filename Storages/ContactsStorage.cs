﻿using ContactListManager.Models;
using ContactListManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactListManager.Storages
{
    public static class ContactsStorage
    {

        private static List<Contact> _contacts = new List<Contact>();

        public static List<ContactViewModel> GetContacts()
        {
            return _contacts.Where(c => !c.IsDeleted).Select(c => c.ToViewModel()).ToList();
        }

        internal static void AddContact(ContactViewModel contact)
        {
            if (contact != null)
            {
                var newContact = new Contact
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    City = contact.City,
                    State = contact.State,
                    StreetAddress = contact.StreetAddress,
                    PhoneNumber = contact.PhoneNumber,
                    PhoneType = contact.PhoneType,
                    PostalCode = contact.PostalCode,
                    IsDeleted = false
                };

                newContact.Id = (_contacts?.Max(c => c.Id) ?? 0) + 1;

                _contacts.Add(newContact);
            }

        }

        internal static void EditContact(ContactViewModel contact)
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

        internal static void DeleteContact(ContactViewModel contact)
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

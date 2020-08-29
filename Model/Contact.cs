using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactListManager.Model
{
    public class Contact
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneTypes PhoneType { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }



        public Contact Clone()
        {
            return new Contact()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                PhoneType = PhoneType,
                StreetAddress = StreetAddress,
                City = City,
                PostalCode = PostalCode,
                State = State
            };
        }
    }

    public enum PhoneTypes
    {
        Mobile = 0,
        Home = 1,
        Work = 2
    }



    public static class ContactsStorage
    {

        private static List<Contact> _contacts = new List<Contact>();

        public static List<Contact> GetContacts()
        {
            return _contacts.Select(item => item.Clone()).ToList();
        }

        public static void AddContact(Contact contact)
        {
            var newContact = contact.Clone();
            newContact.Id = (_contacts?.Max(c => c.Id) ?? 0) + 1;

            _contacts.Add(newContact.Clone());
        }

    }
}

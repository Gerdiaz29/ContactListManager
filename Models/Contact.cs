using ContactListManager.Enums;
using ContactListManager.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactListManager.Models
{
    public class Contact
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneTypes? PhoneType { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public bool IsDeleted { get; set; }

        public ContactViewModel ToViewModel()
        {
            return new ContactViewModel()
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
                State = State,
            };
        }
    }
}

using ContactListManager.Enums;
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
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public PhoneTypes? PhoneType { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public bool IsDeleted { get; set; }

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
                State = State,
                IsDeleted=IsDeleted
            };
        }
    }
}

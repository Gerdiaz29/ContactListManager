using ContactListManager.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ContactListManager.ViewModels
{
    public class ContactViewModel
    {
        [Display(Name = "ID")]
        public int? Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Phone Type")]
        public PhoneTypes? PhoneType { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
    }
}

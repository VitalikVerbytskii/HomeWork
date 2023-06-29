using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberBooklib
{
    public class Contact
    {
        public string FirstName;
        public string LastName;
        public string PhoneNumber;
        public string Address;
        public string Email;

        public Contact(string firstName, string lastName, string phoneNumber, string address, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
            
        }

        public string ContactToString()
        {
            return $@"
First Name: {FirstName}
Last Name: {LastName}
Phone Number: {PhoneNumber}
Address: {Address}
Email: {Email}";
        }
    }
}

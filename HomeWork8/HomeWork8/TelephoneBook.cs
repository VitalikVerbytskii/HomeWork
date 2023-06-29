using PhoneNumberBooklib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8
{
    internal class TelephoneBook
    {
        private List<Contact> _listOfContacts = new List<Contact>();
        public void AddContact()
        {
            Console.WriteLine("Enter first name: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter last name: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Enter phone number: ");
            var phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter address: ");
            var address = Console.ReadLine();

            Console.WriteLine("Enter email: ");
            var email = Console.ReadLine();

          

            _listOfContacts.Add(new Contact(firstName, lastName, phoneNumber,address ,email )
            {
                PhoneNumber = phoneNumber
            });
        }


        public void SearchContactByPhoneNumber(string number)
        {
            Console.WriteLine();
            foreach (var contact in _listOfContacts)
            {
                if (contact.PhoneNumber == number)
                {
                    Console.WriteLine(contact.ContactToString());
                }
            }
        }
        public void SearchContactByFirstName(string FirstName)
        {
            Console.WriteLine();
            foreach (var contact in _listOfContacts)
            { if (contact.FirstName == FirstName) 
                { 
                    Console.WriteLine(contact.ContactToString());
                } 
            }
        }
        public void SerchContactByLastName(string LastName) 
        {
            Console.WriteLine();
            foreach(var contact in _listOfContacts)
            { if (contact.LastName == LastName)
                { 
                    Console.WriteLine(contact.ContactToString());
                }
            }
        }
        public void DisplayAllContacts()
        {
            foreach (var contact in _listOfContacts)
            {
                Console.WriteLine(contact.ContactToString());
            }
        }
    }
}

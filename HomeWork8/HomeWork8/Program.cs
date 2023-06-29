using HomeWork8;
using PhoneNumberBooklib;
using static System.Formats.Asn1.AsnWriter;

internal class Program
{

    static void Main(string[] args)
    {
       TelephoneBook telephoneBook = new TelephoneBook();

        while (true)
        {
            Console.WriteLine("If you want to add contact write: Add");
            Console.WriteLine("If you want to display contacts write: Contacts");
            Console.WriteLine("If you want to search contact by firste name/last name/telephone number write: Search");
            Console.WriteLine("If you want to stop write: Stop");

            Console.WriteLine();

            string command =Console.ReadLine();

            Console.WriteLine();

            if (command == "Add")
            {
                telephoneBook.AddContact();
                Console.WriteLine();
            }
            else if (command == "Contacts")
            { 
                telephoneBook.DisplayAllContacts();
                Console.WriteLine();
            }

            else if (command == "Search")
            {
                var value = Console.ReadLine();
                telephoneBook.SearchContactByPhoneNumber(value);
                telephoneBook.SearchContactByFirstName(value);
                telephoneBook.SerchContactByLastName(value); 
                Console.WriteLine();
            }
            else if (command == "Stop")
            {
                break;
            }

        }

    }
}





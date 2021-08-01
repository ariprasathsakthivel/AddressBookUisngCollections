using System;

namespace AddressBookUsingCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address book program");

            AddressBook.AddContact();
            AddressBook.ContactsDisplay();
        }
    }
}

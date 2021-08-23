using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AddressBookUsingCollections
{
    class AddressBookDriver
    {
        public static void Driver()
        {
            if (File.Exists(@"E:\C#\AddressBookUsingCollections\AddressBookData\AddressBook.csv"))
            {
                AddressBook.DeserializePass();
            }
            else
            {
                AddressBook.Serializepass();
            }
            int flag = 0;
            while (true)
            {
            InvalidInput:
                Console.WriteLine("Enter a number/n" +
                    "1. Adding contacts in new addressbook or existing addressbook\n" +
                    "2. Edit a contact\n" +
                    "3. Delete contact\n" +
                    "4. Search and display persons based on their city and state  and their counts\n" +
                    "5. Sort a addressbook based on person's first name\n" +
                    "6. Display complete addressBook\n" +
                    "7. Display a contact based on person's first name\n" +
                    "8. Exit\n");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        AddressBook.addressBookNewExisting();
                        AddressBook.Serializepass();
                        AddressBook.DeserializePass();
                        break;
                    case 2:
                        AddressBook.EditContact();
                        AddressBook.Serializepass();
                        AddressBook.DeserializePass();
                        break;
                    case 3:
                        AddressBook.DeleteContact();
                        AddressBook.Serializepass();
                        AddressBook.DeserializePass();
                        break;
                    case 4:
                        AddressBook.PersonSearch();
                        break;
                    case 5:
                        AddressBook.AddressBookSorting();
                        AddressBook.Serializepass();
                        AddressBook.DeserializePass();
                        break;
                    case 6:
                        AddressBook.AddressBookDisplay();
                        break;
                    case 7:
                        AddressBook.ContactsDisplay();
                        break;
                    case 8:
                        flag = 1;
                        break;
                    default:
                        Console.WriteLine("PLEASE ENTER A VALID NUMBER\n");
                        goto InvalidInput;
                }
                

                if (flag==1)
                {
                    break;
                }

            }


        }
    }
}

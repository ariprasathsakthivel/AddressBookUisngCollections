using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookUsingCollections
{
    class AddressBook
    {
        public static Dictionary<string, List<Contacts>> mySystem = new Dictionary<string, List<Contacts>>();
        public static List<Contacts> addressBook = new List<Contacts>();

        public static void Serializepass()
        {

            JSONSerializations.Serializations(mySystem);
        }
        public static void DeserializePass()
        {
            mySystem.Clear();
            mySystem = JSONDeserialization.Deserialization(typeof(Dictionary<string,List<Contacts>>));
        }

        public static void addressBookNewExisting()
        {
            Console.WriteLine("Enter a input\n" +
                "1. New addresbook\n" +
                "2. Existing addressbook");
            int key = Convert.ToInt32(Console.ReadLine());
            if (key==1)
            {
                addAddressBook();
            }
            else if (key==2)
            {
                AddressBookExistingNameValidator();
            }
        }

        public static void addAddressBook()
        {
            Console.WriteLine("How many addressbooks do you want to create?");
            int count = Convert.ToInt32(Console.ReadLine());
            while (count > 0)
            {
                AddressBookNewNameValidator();
                count--;
            }
        }

        public static void AddressBookNewNameValidator()
        {
            Console.WriteLine("Enter the new addressbook name\n");
            string addressBookName = Console.ReadLine();
            if (mySystem.ContainsKey(addressBookName))
            {
                Console.WriteLine("Please enter a new addressbook name. The name entered already exist");
                AddressBookNewNameValidator();
            }
            else
            {
                mySystem[addressBookName] = new List<Contacts>();
                AddContact(addressBookName);
            }
        }
        public static void AddressBookExistingNameValidator()
        {
            Console.WriteLine("Enter the Existing addressbook name\n");
            string addressBookName = Console.ReadLine();
            if (mySystem.Count > 0)
            {
                if (!mySystem.ContainsKey(addressBookName))
                {
                    Console.WriteLine("Please enter a new addressbook name. The name entered is not available");
                    AddressBookExistingNameValidator();
                }
                else
                {
                    AddContact(addressBookName);
                }
            }
            else
            {
                Console.WriteLine("The system has no adressbooks");
                addressBookNewExisting();
            }
        }
        public static void AddContact(string addressBookName)
        {
            Console.WriteLine("How many person's contact details do you want to add?");
            int personNum = Convert.ToInt32(Console.ReadLine());
            while (personNum > 0)
            {
                Contacts person = new Contacts();
                firstName:
                Console.WriteLine("Enter your First name");
                string firstName = Console.ReadLine();
                if (NameDuplicationCheck(addressBookName, firstName))
                {
                    person.firstName = firstName;
                }
                else
                {
                    Console.WriteLine("The name {0} already  exist in the current address book. please enter a new name",firstName);
                    goto firstName;
                }

                Console.WriteLine("Enter your Last name");
                person.lastName = Console.ReadLine();
                Console.WriteLine("Enter your address");
                person.address = Console.ReadLine();
                Console.WriteLine("Enter your city");
                person.city = Console.ReadLine();
                Console.WriteLine("Enter your State");
                person.state = Console.ReadLine();
                Console.WriteLine("Enter your Zip code");
                person.ZipCode = Console.ReadLine();
                Console.WriteLine("Enter your Phone number");
                person.PhoneNunmber = Console.ReadLine();
                Console.WriteLine("Enter your Email ID");
                person.eMail = Console.ReadLine();

                mySystem[addressBookName].Add(person);
                Console.WriteLine("{0}'s contact succesfully added", person.firstName);

                personNum--;
            }
        }

        public static bool NameDuplicationCheck(string addressBookName, string firstName )
        {
            int flag = 0;
            if (mySystem[addressBookName].Count > 0)
            {
                foreach (Contacts contact in mySystem[addressBookName])
                {
                    if (!(contact.firstName==firstName))
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
            }
            else
            {
                return true;
            }
            if (flag == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void AddressBookDisplay()
        {
            if (mySystem.Count > 0)
            {
                Console.WriteLine("Enter the name of the addressbook that you wants to use for displaying contacts");
                string addressBookName = Console.ReadLine();
                if (mySystem[addressBookName].Count > 0)
                {
                    foreach (Contacts contact in mySystem[addressBookName])
                    {
                        Console.WriteLine("First name-->{0}", contact.firstName);
                        Console.WriteLine("Last name-->{0}", contact.lastName);
                        Console.WriteLine("Address-->{0}", contact.address);
                        Console.WriteLine("City-->{0}", contact.city);
                        Console.WriteLine("State-->{0}", contact.state);
                        Console.WriteLine("Zip code-->{0}", contact.ZipCode);
                        Console.WriteLine("Phone number-->{0}", contact.PhoneNunmber);
                        Console.WriteLine("E-Mail ID-->{0}", contact.eMail);
                    }
                }
                else
                {
                    Console.WriteLine("Your address book is empty");
                }
            }
            else
            {
                Console.WriteLine("You don't have any addressbook");
            }
        }

        public static void ContactsDisplay()
        {
            if (mySystem.Count > 0)
            {
                Console.WriteLine("Enter the name of the addressbook that you wants to use for displaying contacts");
                string addressBookName = Console.ReadLine();
                if (mySystem[addressBookName].Count > 0)
                {
                    Console.WriteLine("Enter the name of the person to get all the contact details");
                    string nameKey = Console.ReadLine();
                    int flag = 0;
                    foreach (Contacts contact in mySystem[addressBookName])
                    {
                        if (nameKey.ToLower() == contact.firstName.ToLower())
                        {
                            flag = 1;
                            Console.WriteLine("First name-->{0}", contact.firstName);
                            Console.WriteLine("Last name-->{0}", contact.lastName);
                            Console.WriteLine("Address-->{0}", contact.address);
                            Console.WriteLine("City-->{0}", contact.city);
                            Console.WriteLine("State-->{0}", contact.state);
                            Console.WriteLine("Zip code-->{0}", contact.ZipCode);
                            Console.WriteLine("Phone number-->{0}", contact.PhoneNunmber);
                            Console.WriteLine("E-Mail ID-->{0}", contact.eMail);
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        Console.WriteLine("contact of the person {0} does not exist", nameKey);
                    }
                }
                else
                {
                    Console.WriteLine("Your address book is empty");
                }
            }
            else
            {
                Console.WriteLine("You don't have any addressbook");
            }
        }

        public static void EditContact()
        {
            if (mySystem.Count > 0)
            {
                Console.WriteLine("Enter the name of the addressbook that you wants to use for editing contacts");
                string addressBookName = Console.ReadLine();
                Console.WriteLine("Enter the first name of the person whoom you want to edit the details");
                string editKey = Console.ReadLine();
                int flag = 0;
                if (mySystem[addressBookName].Count > 0)
                {
                    foreach (Contacts contact in mySystem[addressBookName])
                    {
                        if (editKey.ToLower() == contact.firstName.ToLower())
                        {
                            while (true)
                            {
                                Console.WriteLine("Enter the key number for editing the details\n 1. First name\n 2. Last name\n 3. Address\n 4. City\n 5. State\n 6. Zipcode\n 7. Phone number\n 8. Email ID\n 9. Exit editor");
                                int key = Convert.ToInt32(Console.ReadLine());
                                switch (key)
                                {
                                    case 1:
                                        Console.WriteLine("Enter the new First name");
                                        contact.firstName = Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter the new Last name");
                                        contact.lastName = Console.ReadLine();
                                        break;
                                    case 3:
                                        Console.WriteLine("Enter the new address");
                                        contact.address = Console.ReadLine();
                                        break;
                                    case 4:
                                        Console.WriteLine("Enter the new city");
                                        contact.city = Console.ReadLine();
                                        break;
                                    case 5:
                                        Console.WriteLine("Enter the new state");
                                        contact.state = Console.ReadLine();
                                        break;
                                    case 6:
                                        Console.WriteLine("Enter the new zip code");
                                        contact.ZipCode = Console.ReadLine();
                                        break;
                                    case 7:
                                        Console.WriteLine("Enter the new phone");
                                        contact.PhoneNunmber = Console.ReadLine();
                                        break;
                                    case 8:
                                        Console.WriteLine("Enter the new E-Mail ID");
                                        contact.eMail = Console.ReadLine();
                                        break;
                                    case 9:
                                        flag = 1;
                                        break;
                                    default:
                                        Console.WriteLine("Please enter a valid input");
                                        EditContact();
                                        break;
                                }
                                if (flag == 1)
                                {
                                    break;
                                }
                            }
                            Console.WriteLine("{0}'s contact has been sucessfully updated", editKey);
                            break;
                        }
                    }
                    if (flag == 0)
                    {

                        Console.WriteLine("contact of the person {0} does not exist", editKey);
                    }
                }
                else
                {
                    Console.WriteLine("Your address book is empty");
                }
            }
            else
            {
                Console.WriteLine("You don't have any addressbook");
            }
        }
        public static void DeleteContact()
        {
            if (mySystem.Count > 0)
            {
                Console.WriteLine("Enter the name of the addressbook that you wants to use for Deleting contacts");
                string addressBookName = Console.ReadLine();
                Console.WriteLine("Enter the first name of the person whose contact you want to delete from the addressbook");
                string deleteKey = Console.ReadLine();
                int flag = 0;
                if (mySystem[addressBookName].Count > 0)
                {
                    foreach (Contacts contact in mySystem[addressBookName])
                    {
                        if (deleteKey.ToLower() == contact.firstName.ToLower())
                        {
                            flag = 1;
                            addressBook.Remove(contact);
                            break;
                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                    Console.WriteLine("Your address book is empty");
                }
                if (flag == 0)
                {

                    Console.WriteLine("contact of the person {0} does not exist", deleteKey);
                }
            }
            else
            {
                Console.WriteLine("You don't have any addressbook");
            }
        }

        public static void PersonSearch()
        {
            Dictionary<string, List<Contacts>> cityPersons = new Dictionary<string, List<Contacts>>();
            Dictionary<string, List<Contacts>> statePerson = new Dictionary<string, List<Contacts>>();
            if (mySystem.Count > 0)
            {
                Console.WriteLine("Enter the city that you want to search");
                string cityKey = Console.ReadLine();
                cityPersons[cityKey] = new List<Contacts>();
                Console.WriteLine("Enter the state that you want to search");
                string stateKey = Console.ReadLine();
                statePerson[stateKey] = new List<Contacts>();
                foreach (string addressBookName in mySystem.Keys)
                {
                    foreach (Contacts contact in mySystem[addressBookName])
                    {
                        if (cityKey.ToLower() == contact.city)
                        {
                            cityPersons[cityKey].Add(contact);
                        }
                        if (stateKey.ToLower() == contact.state)
                        {
                            statePerson[stateKey].Add(contact);
                        }
                    }
                }
                PersonSearchDisplay(cityPersons, statePerson, cityKey, stateKey);
            }
            else
            {
                Console.WriteLine("You don't have any addressbook");
            }
        }

        public static void PersonSearchDisplay(Dictionary<string,List<Contacts>> cityPersons, Dictionary<string,List<Contacts>> statePersons, string cityKey, string stateKey)
        {
            Console.WriteLine("------------------- Persons in {0} city-------------------------",cityKey);
            foreach (Contacts contact in cityPersons[cityKey])
            {
                Console.WriteLine("{0}", contact.firstName);
            }
            Console.WriteLine("Total count of persons in the city {0} is {1}",cityKey,cityPersons[cityKey].Count);
            Console.WriteLine("--------------------Persons in {0} state", stateKey);
            foreach (Contacts contact in statePersons[stateKey])
            {
                Console.WriteLine("{0}", contact.firstName);
            }
            Console.WriteLine("Total count of persons in the state {0} is {1}", stateKey, statePersons[stateKey].Count);
        }

        public static void AddressBookSorting()
        {
            if (mySystem.Count > 0)
            {
                Console.WriteLine("Enter the addressbook name that you want to sort it");
                string addressBookName = Console.ReadLine();

                if (mySystem.ContainsKey(addressBookName))
                {
                    SortBy(addressBookName);
                }
                else
                {
                    Console.WriteLine("The given addressbook does not exist. please enter a valid addressbook  name");
                    AddressBookSorting();
                }
            }
            else
            {
                Console.WriteLine("You don't have any addressbook");
            }
        }
        public static void SortBy(string addressBookName)
        {
            Console.WriteLine("How do you want the addressbook to be sorted?\n Enter\n1 to sort based on City\n2 to sort based on State\n3 to sort based on Zipcode");
            switch (Console.ReadLine())
            {
                case "1":
                    mySystem[addressBookName].Sort((x, y) => x.city.CompareTo(y.city));
                    Console.WriteLine("Sorted by City");
                    break;
                case "2":
                    mySystem[addressBookName].Sort((x, y) => x.state.CompareTo(y.state));
                    Console.WriteLine("Sorted by State");
                    break;
                case "3":
                    mySystem[addressBookName].Sort((x, y) => x.ZipCode.CompareTo(y.ZipCode));
                    Console.WriteLine("Sorted by ZipCode");
                    break;
            }
        }
    }
}



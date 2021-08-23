using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace AddressBookUsingCollections
{
    class CSVSerializations
    {
        public static void Serializations(Dictionary<string,List<Contacts>> mySystem)
        {
            string csvPath = @"E:\C#\AddressBookUsingCollections\AddressBookData\AddressBook.csv";
            bool headerCheck = false;
            if (File.Exists(csvPath))
            {
                if (File.ReadAllText(csvPath) != "")
                {
                    headerCheck = File.ReadAllLines(csvPath)[0] == "AddressBookName,FirstName,LastName,Address,City,State,Zip,Contact,Email";
                }
                File.WriteAllText(csvPath, String.Empty);
                using (StreamWriter streamWriter = File.AppendText(csvPath))
                {
                    if (!headerCheck)
                    {
                        streamWriter.WriteLine("AddressBookName,FirstName,LastName,Address,City,State,Zip,Contact,Email");
                        foreach (string addressbookName in mySystem.Keys)
                        {
                            foreach (Contacts contact in mySystem[addressbookName])
                            {
                                streamWriter.WriteLine(addressbookName + "," + contact.firstName + "," + contact.lastName + "," + contact.address + "," + contact.city + "," + contact.state + "," + contact.ZipCode + "," + contact.PhoneNunmber + "," + contact.eMail);
                            }
                            Console.WriteLine("Contacts Stored in Csv_File.");

                        }
                    }
                    else
                    {
                        foreach (string addressbookName in mySystem.Keys)
                        {
                            foreach (Contacts contact in mySystem[addressbookName])
                            {
                                streamWriter.WriteLine(addressbookName + "," + contact.firstName + "," + contact.lastName + "," + contact.address + "," + contact.city + "," + contact.state + "," + contact.ZipCode + "," + contact.PhoneNunmber + "," + contact.eMail);
                            }
                            Console.WriteLine("Contacts Stored in Csv_File.");

                        }
                    }
                    streamWriter.Close();

                }
            }
            else
            {
                File.Create(csvPath);
            }
        }
    }
}

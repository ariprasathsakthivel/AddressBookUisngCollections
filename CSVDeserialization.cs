using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using CsvHelper;

namespace AddressBookUsingCollections
{
    class CSVDeserialization
    {
        public static Dictionary<string, List<Contacts>> Deserialization()
        {
            List<string> keys = new List<string>();
            List<Contacts> contacts=new List<Contacts>();
            Dictionary<string, List<Contacts>> MySystem = new Dictionary<string, List<Contacts>>();
            
            string csvPath = @"E:\C#\AddressBookUsingCollections\AddressBookData\AddressBook.csv";
            if (File.Exists(csvPath))
            {
                using (StreamReader streamReader = File.OpenText(csvPath))
                {
                    string data = "";
                    while ((data = streamReader.ReadLine()) != null)
                    {
                        string[] csv = data.Split(",");
                        Contacts person = new Contacts();
                        person.firstName = csv[1];
                        person.lastName = csv[2];
                        person.address = csv[3];
                        person.city = csv[4];
                        person.state = csv[5];
                        person.ZipCode = csv[6];
                        person.PhoneNunmber = csv[7];
                        person.eMail = csv[8];
                        if (MySystem.ContainsKey(csv[0]))
                        {
                            MySystem[csv[0]].Add(person);
                        }
                        else
                        {
                            MySystem[csv[0]] = new List<Contacts>();
                            MySystem[csv[0]].Add(person);
                        }
                    }
                    streamReader.Close();
                }
            }
            else
            {
                Console.WriteLine("File not avilable..");
            }

            return MySystem;

        }
    }
}

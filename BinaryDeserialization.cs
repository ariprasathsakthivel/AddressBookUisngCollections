using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AddressBookUsingCollections
{
    class BinaryDeserialization
    {
        public static Dictionary<string, List<Contacts>> Deserialization()
        {
            Dictionary<string, List<Contacts>> MySystem = new Dictionary<string, List<Contacts>>();
            FileStream fileStream = new FileStream(@"E:\C#\AddressBookUsingCollections\AddressBookData\AddressBook.txt", FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MySystem= (Dictionary<string, List<Contacts>>)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();

            return MySystem;

        }
    }
}

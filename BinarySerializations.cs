using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace AddressBookUsingCollections
{
    class BinarySerializations
    {
        public static void Serializations(Dictionary<string,List<Contacts>> mySystem)
        {
            FileStream fileStream = new FileStream(@"E:\C#\AddressBookUsingCollections\AddressBookData\AddressBook.txt", FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, mySystem);
            fileStream.Close();

        }
    }
}

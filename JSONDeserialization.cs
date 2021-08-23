using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using Newtonsoft.Json;

namespace AddressBookUsingCollections
{
    class JSONDeserialization
    {
        public static Dictionary<string, List<Contacts>> Deserialization(Type type)
        {
            FileStream fileStream = new FileStream(@"E:\C#\AddressBookUsingCollections\AddressBookData\AddressBook.txt", FileMode.Open);
            JsonSerializer jsonSerializer = new JsonSerializer();
            StreamReader streamReader = new StreamReader(fileStream);
            Dictionary<string, List<Contacts>> MySystem = (Dictionary<string, List<Contacts>>)jsonSerializer.Deserialize(streamReader, type);
            return MySystem;

        }
    }
}

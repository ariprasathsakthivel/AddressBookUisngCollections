using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace AddressBookUsingCollections
{
    class JSONSerializations
    {
        public static void Serializations(Dictionary<string,List<Contacts>> mySystem)
        {
            FileStream fileStream = new FileStream(@"E:\C#\AddressBookUsingCollections\AddressBookData\AddressBook.txt", FileMode.Create);
            JsonSerializer jsonSerializer = new JsonSerializer();
            StreamWriter streamWriter = new StreamWriter(fileStream);
            jsonSerializer.Serialize(streamWriter, mySystem);
            streamWriter.Close();
            fileStream.Close();
        }
    }
}

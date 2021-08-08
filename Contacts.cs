using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AddressBookUsingCollections
{
    [Serializable]
    class Contacts
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNunmber { get; set; }
        public string eMail { get; set; }
    }
}

using System;

namespace AddressBookSystemADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Address Book System ADO.NET");

            AddressBookManagement addressBookManagement = new AddressBookManagement();

            //UC1
            //addressBookManagement.DataBaseConnection();

            //UC2
            addressBookManagement.GetAllContact(); 
        }
    }
}

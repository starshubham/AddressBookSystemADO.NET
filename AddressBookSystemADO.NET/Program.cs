using System;

namespace AddressBookSystemADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Address Book System ADO.NET");

            AddressBookManagement addressBookManagement = new AddressBookManagement();

            //UC1
            //addressBookManagement.DataBaseConnection();

            //UC2
            //addressBookManagement.GetAllContact();

            //UC3
            AddNewContactDetails();
        }

        /* UC3:- Ability to insert new Contacts to Address Book */
        public static void AddNewContactDetails()
        {
            AddressBookManagement repository = new AddressBookManagement();
            AddressBookModel model = new AddressBookModel();
            model.FirstName = "Ekta";
            model.LastName = "Kapoor";
            model.Address = "Durga Kund";
            model.City = "Varanasi";
            model.State = "UP";
            model.Zip = "222105";
            model.PhoneNumber = "1234567891";
            model.EmailId = "ekta@gmail.com";
            model.AddressBookType = "Friend";
            model.AddressBookName = "Ekta";

            Console.WriteLine(repository.AddDataToTable(model) ? "Record inserted successfully\n" : "Record inserted Failed");
        }
    }
}

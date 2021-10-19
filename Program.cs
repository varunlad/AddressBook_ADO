using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookRepository addressBook = new AddressBookRepository();
            addressBook.GetAllAddressBook();
            //For adding employee
            AddressModel model = new AddressModel();
            model.FName = "Bharat";
            model.LName = "Patil";
            model.City = "Panvel";
            model.State = "Maharashtra";
            model.Phone = 9834516242;
            model.Address = "Rasayani";
            model.Email = "bharatpatil19@gmail.com";
            model.ZipCode = 410222;
            addressBook.AddAddress(model);
            Console.ReadLine();
        }
    }
}

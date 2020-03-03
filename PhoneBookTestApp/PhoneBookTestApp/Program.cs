using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Program
    {
        private PhoneBook phonebook = new PhoneBook();
        static void Main(string[] args)
        {
            string name = string.Empty;
            try
            {
                DatabaseUtil.initializeDatabase();
                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */

                // TODO: print the phone book out to System.out
                // TODO: find Cynthia Smith and print out just her entry
                // TODO: insert the new person objects into the database
                
                Program pm = new Program();
                pm.AddPersons();
                pm.GetAllPersons();
                Console.WriteLine("Search the person : ");
                name=Console.ReadLine();
                pm.FindPersonDetails(name);
                Console.WriteLine("Enter the new person details");
                pm.AddNewPerson();
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
        /// <summary>
        /// Adds New person details in the database
        /// </summary>
        public void AddNewPerson()
        {
            Person p = new Person();
            Console.WriteLine("Enter the person name");
            p.name = Console.ReadLine();
            Console.WriteLine("Enter the person phoneNumber");
            p.phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter the person address");
            p.address = Console.ReadLine();
            phonebook.AddPerson(p);
            GetAllPersons();
        }
        /// <summary>
        /// Adds person details in the database
        /// </summary>
        public void AddPersons()
        {
            phonebook.AddPerson(new Person { name = "John Smith", phoneNumber = "(248) 123-4567", address = "1234 Sand Hill Dr, Royal Oak, MI" });
            phonebook.AddPerson(new Person { name = "Cynthia Smith", phoneNumber = "(824) 128-8758", address = "875 Main St, Ann Arbor, MI" });
        }

        /// <summary>
        /// Retrives the details from database
        /// </summary>
        public void GetAllPersons()
        {
            var personlist = phonebook.GetAllPersons();
            for(int i=0; i< personlist.Count; i++)
            {
                Console.WriteLine("Name = {0}, Phonenumber = {1}, Address = {2}",personlist[i].name,personlist[i].phoneNumber,personlist[i].address);
            }
        }

        public void FindPersonDetails(string name)
        {
            var persondteils = phonebook.findPerson(name);
            Console.WriteLine("Name = {0}, Phonenumber = {1}, Address = {2}", persondteils.name, persondteils.phoneNumber, persondteils.address);
            Console.ReadKey();
        }
    }
}

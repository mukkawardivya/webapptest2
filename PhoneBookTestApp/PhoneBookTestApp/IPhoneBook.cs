using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public interface IPhoneBook
    {
        Person findPerson(string name);
        void AddPerson(Person newPerson);

        IList<Person> GetAllPersons();

    }
}
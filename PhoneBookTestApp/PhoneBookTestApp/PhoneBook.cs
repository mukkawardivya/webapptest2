using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {

        /// <summary>
        /// Adds person details 
        /// </summary>
        /// <param name="person"></param>
        public void AddPerson(Person person)
        {
            var dbcontext = DatabaseUtil.GetConnection();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(dbcontext))
                {
                    string query = "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES(@name,@phonenumber, @address)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", person.name);
                        cmd.Parameters.AddWithValue("@phonenumber", person.phoneNumber);
                        cmd.Parameters.AddWithValue("@address", person.address);
                        var objectResult = cmd.ExecuteScalar();
                        int Result = Convert.ToInt32(objectResult);
                        //int result = cmd.ExecuteNonQuery();
                        if (Result < 0)
                        {
                            Console.WriteLine("Error while inserting data");
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Person findPerson()
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Find a person with Name
        /// </summary>
        /// <param name="firstName">First Name </param>
        /// <param name="lastName"> Last Name</param>
        /// <returns></returns>
        public Person findPerson(string name)
        {
            var dbContext = DatabaseUtil.GetConnection();
            Person p = new Person();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(dbContext))
                {
                    string query = "Select * from PhoneBook where name like '%" + name + "%' order by name asc";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                p.name = dataReader.GetString(0);
                                p.phoneNumber = dataReader.GetString(1);
                                p.address = dataReader.GetString(2);
                            }
                        }
                    }

                }
            }

            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return p;
        }

        /// <summary>
        /// Fetches all persons data from database
        /// </summary>
        /// <returns></returns>
        public IList<Person> GetAllPersons()
        {
            var dbContext = DatabaseUtil.GetConnection();
            IList<Person> personList = new List<Person>();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(dbContext))
                {
                    string query = "Select * from PhoneBook";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Person p = new Person();
                                p.name = dataReader.GetString(0);
                                p.phoneNumber = dataReader.GetString(1);
                                p.address = dataReader.GetString(2);
                                personList.Add(p);
                            }
                        }
                    }
                }

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

            return personList;
        }
    }
}
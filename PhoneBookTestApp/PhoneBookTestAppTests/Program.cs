using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookTestApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestAppTests
{
    [TestClass]
    public class PhoneBookTestAppTests
    {
        PhoneBook pb = new PhoneBook();
        static void Main(string[] args)
        {

        }

        [TestMethod]
        public void AllPersonsTest()
        {
            var results = pb.GetAllPersons();
            var count = results.Count();
            Assert.Equals(4, count);
        }

        [TestMethod]
        public void FindPersonTest()
        {
            var person = pb.findPerson("John");
            Assert.Equals(1, person.name);
        }
    }
}



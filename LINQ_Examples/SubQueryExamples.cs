using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using LING_Examples.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using LING_Examples.Entities;

namespace LING_Examples {
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class LinqMethodSyntaxQueryOneToManyCollectionShould {
        public LinqMethodSyntaxQueryOneToManyCollectionShould() {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void SimpleSubqueryTest() {
            List<string> names = new List<string> { "Jodi", "Charlotte", "James", "Kay" };
            var query = from name in names
                        let firstName = (
                                            from name2 in names
                                            where (name2.Substring(0, 1) == "J")
                                            select name2
                                        )
                        where firstName.Contains(name)
                        select name;

            Assert.IsTrue(query.Count() > 2);
        }

        [TestMethod]
        public void Test2() {
            List<Contact> contacts1 = new List<Contact>() { new Contact() { FirstName = "jorge1", LastName = "perez1", Id = 1 }, new Contact() { FirstName = "jorge4", LastName = "perez4", Id = 4 } };
            List<Contact> contacts2 = new List<Contact>() { new Contact() { FirstName = "jorge2", LastName = "perez2", Id = 2 }, new Contact() { FirstName = "jorge3", LastName = "perez3", Id = 1 } };
            var test2NotInTest1 = contacts2.Where(t2 => contacts1.Any(t1 => t2.Id == t1.Id));
            Assert.AreNotEqual(0, test2NotInTest1.Count());
        }
    }
}

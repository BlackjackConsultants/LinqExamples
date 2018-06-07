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
    public class JoinExamplesUsingQuerySyntax {
        public JoinExamplesUsingQuerySyntax() { }
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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// filter by id
        /// </summary>
        /// 
        [TestMethod]
        public void InnerJoinByIds() {
            // Example customers.
            var customers = new Person[]
	        {
	            new Person{Id = 1, Name = "Sam"},
	            new Person{Id = 2, Name = "Dave"},
	            new Person{Id = 3, Name = "Julia"},
	            new Person{Id = 4, Name = "Sue"},
	            new Person{Id = 5, Name = "DontHaveOrder"}
	        };

            // Example orders.
            var orders = new Order[]
	        {
	            new Order{Id = 100, PersonId = 1, ItemName = "Book"},
	            new Order{Id = 101, PersonId = 2, ItemName = "Game"},
	            new Order{Id = 102, PersonId = 3, ItemName = "Computer"},
	            new Order{Id = 103, PersonId = 4, ItemName = "Shirt"},
	            new Order{Id = 104, PersonId = 0, ItemName = "DontHavePerson"}
	        };

            var query = from c in customers
                        join o in orders on c.Id equals o.PersonId 
                        select new {
                            c.Id,
                            CustomerName = c.Name,
                            ItemName = o.ItemName 
                        };

            // Display joined groups.
            foreach (var result in query) {
                TestContext.WriteLine("person: " + result.CustomerName + ", person id: " + result.Id + ", order id: " + result.ItemName);
            }
        }

        [TestMethod]
        public void LeftOuterJoinByIds() {
            // Example customers.
            var customers = new Person[]
	        {
	            new Person{Id = 1, Name = "Sam"},
	            new Person{Id = 2, Name = "Dave"},
	            new Person{Id = 3, Name = "Julia"},
	            new Person{Id = 4, Name = "Sue"},
	            new Person{Id = 5, Name = "DontHaveOrder"}
	        };

            // Example orders.
            var orders = new Order[]
	        {
	            new Order{Id = 100, PersonId = 1, ItemName = "Book"},
	            new Order{Id = 101, PersonId = 2, ItemName = "Game"},
	            new Order{Id = 102, PersonId = 3, ItemName = "Computer"},
	            new Order{Id = 103, PersonId = 4, ItemName = "Shirt"},
	            new Order{Id = 104, PersonId = 0, ItemName = "DontHavePerson"}
	        };

            var query = from c in customers
                        join o in orders on c.Id equals o.PersonId into oj
                        from o in oj.DefaultIfEmpty()
                        select new {
                            c.Id,
                            CustomerName = c.Name,
                            ItemName = (o != null) ? o.ItemName : string.Empty
                        };

            // Display joined groups.
            foreach (var result in query) {
                TestContext.WriteLine("person: " + result.CustomerName + ", person id: " + result.Id + ", order id: " + result.ItemName);
            }
        }

        [TestMethod]
        public void RightOuterJoinByIds() {
            // Example customers.
            var customers = new Person[]
	        {
	            new Person{Id = 1, Name = "Sam"},
	            new Person{Id = 2, Name = "Dave"},
	            new Person{Id = 3, Name = "Julia"},
	            new Person{Id = 4, Name = "Sue"},
	            new Person{Id = 5, Name = "DontHaveOrder"}
	        };

            // Example orders.
            var orders = new Order[]
	        {
	            new Order{Id = 100, PersonId = 1, ItemName = "Book"},
	            new Order{Id = 101, PersonId = 2, ItemName = "Game"},
	            new Order{Id = 102, PersonId = 3, ItemName = "Computer"},
	            new Order{Id = 103, PersonId = 4, ItemName = "Shirt"},
	            new Order{Id = 104, PersonId = 0, ItemName = "DontHavePerson"}
	        };

            var query = from o in orders
                        join c in customers on o.PersonId equals c.Id into cj
                        from c in cj.DefaultIfEmpty()
                        select new {
                            Id = (c != null) ? c.Id : 0, 
                            ItemName = o.ItemName,
                            CustomerName = (c != null) ? c.Name : string.Empty
                        };

            // Display joined groups.
            foreach (var result in query) {
                TestContext.WriteLine("person: " + result.CustomerName + ", person id: " + result.Id + ", order id: " + result.ItemName);
            }
        }
    }
}

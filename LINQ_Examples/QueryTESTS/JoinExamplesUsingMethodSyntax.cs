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
    public class JoinExamplesUsingMethodSyntax {
        public JoinExamplesUsingMethodSyntax() { }
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
        [TestMethod]
        public void InnerJoinUsingObjectToJoin() {
            Person magnus = new Person { Name = "Hedlund, Magnus" };
            Person terry = new Person { Name = "Adams, Terry" };
            Person charlotte = new Person { Name = "Weiss, Charlotte" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            List<Person> people = new List<Person> { magnus, terry, charlotte };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

            // Create a list of Person-Pet pairs where  
            // each element is an anonymous type that contains a 
            // Pet's name and the name of the Person that owns the Pet. 
            var query = people.Join(pets, person => person, pet => pet.Owner,
                                (person, pet) =>
                                new { OwnerName = person.Name, Pet = pet.Name });

            foreach (var obj in query) {
                TestContext.WriteLine("{0} - {1}", obj.OwnerName, obj.Pet);
            }

        }

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
	            new Order{Id = 104, PersonId = 7, ItemName = "DontHavePerson"}
	        };

            // Join on the ID properties.
            var results = customers.Join(orders, c => c.Id, o => o.PersonId, (c, o) => new {
                c,
                o
            });

            // Display joined groups.
            foreach (var result in results) {
                TestContext.WriteLine("person: " + result.c.Name + ", person id: " + result.c.Id + ", order id: " + result.o.Id);
            }
        }

        [TestMethod]
        public void LeftInnerJoinByIds() {
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

            // Join on the ID properties.
            var results = customers.GroupJoin(orders, c => c.Id, o => o.PersonId, (c, o) => new {
                                        c,
                                        o
                                    })
                                    .SelectMany(x => x.o.DefaultIfEmpty(new Order{
                                        Id = 0, 
                                        ItemName = "NULL", 
                                        PersonId = 0
                                    }),
                                    (x, y) => new {
                                        x.c.Id,
                                        CustomerName = x.c.Name,
                                        ItemName = y.ItemName
                                    });

            // Display joined groups.
            foreach (var result in results) {
                TestContext.WriteLine("person: " + result.CustomerName + ", person id: " + result.Id + ", order id: " + result.ItemName);
            }
        }

		//[TestMethod]
		//public void RightInnerJoinByIds() {
		//	// Example customers.
		//	var customers = new Person[]
		//	{
		//		new Person{Id = 1, Name = "Sam"},
		//		new Person{Id = 2, Name = "Dave"},
		//		new Person{Id = 3, Name = "Julia"},
		//		new Person{Id = 4, Name = "Sue"},
		//		new Person{Id = 5, Name = "DontHaveOrder"}
		//	};

		//	// Example orders.
		//	var orders = new Order[]
		//	{
		//		new Order{Id = 100, PersonId = 1, ItemName = "Book"},
		//		new Order{Id = 101, PersonId = 2, ItemName = "Game"},
		//		new Order{Id = 102, PersonId = 3, ItemName = "Computer"},
		//		new Order{Id = 103, PersonId = 4, ItemName = "Shirt"},
		//		new Order{Id = 104, PersonId = 0, ItemName = "DontHavePerson"}
		//	};

		//	// Join on the ID properties.
		//	var results = customers.GroupJoin(orders, c => c.Id, o => o.PersonId, (c, o) => new {
		//		c,
		//		o
		//	})
		//							.SelectMany(x => x.o(new Person {
		//								Id = 0,
		//								Name = "NULL"
		//							}),
		//							(x, y) => new {
		//								x.c.Id,
		//								CustomerName = x.c.Name,
		//								ItemName = 
		//							});

		//	// Display joined groups.
		//	foreach (var result in results) {
		//		TestContext.WriteLine("person: " + result.CustomerName + ", person id: " + result.Id + ", order id: " + result.ItemName);
		//	}
		//}
    }
}

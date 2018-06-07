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
    public class OrderByExamplesUsingMethodSyntax {
		public OrderByExamplesUsingMethodSyntax() {}

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

		/// <summary>
		/// this example shows where orderby goes in query, after where
		/// </summary>
        [TestMethod]
        public void OrderByLocationInQuery() {
            var contacts1 = new List<Contact>() {
	            new Contact() { FirstName = "jorge19", LastName = "perez11", Id = 1 }, 
				new Contact() { FirstName = "jorge92", LastName = "perez2", Id = 2 },
				new Contact() { FirstName = "jorge84", LastName = "perez15", Id = 5 },
				new Contact() { FirstName = "jorge28", LastName = "perez61", Id = 6 },
	            new Contact() { FirstName = "jorge73", LastName = "perez21", Id = 1 }, 
				new Contact() { FirstName = "jorge57", LastName = "perez24", Id = 2 },
				new Contact() { FirstName = "jorge75", LastName = "perez34", Id = 3 },
				new Contact() { FirstName = "jorge56", LastName = "perez54", Id = 4 }
            };
			var contactsResults = contacts1
				.Where(t2 => t2.Id < 8)
				.OrderBy(o => o.LastName)
				.Select(s => s);

			var resultsList = contactsResults.ToList();
			Assert.AreEqual(resultsList[0].LastName, "perez11");
        }
    }
}

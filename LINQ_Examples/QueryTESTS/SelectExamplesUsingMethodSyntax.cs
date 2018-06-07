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
	public class SelectExamplesUsingMethodSyntax {
		public SelectExamplesUsingMethodSyntax() {}
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

		[TestMethod]
		public void SelectingOneField() {
            List<Contact> contacts2 = Factory.CreateContactsForGrouping();
            var contacsResults = contacts2
                .Where(c => c.Id == 1)
                .Select(cc => cc.FirstName);

            foreach (var firstName in contacsResults) {
                TestContext.WriteLine("firstName: " + firstName);
                Assert.AreEqual("jorge", firstName);
            }
		}

        [TestMethod]
        public void SelectingOneObjectOfDataSource() {
            List<Contact> contacts2 = Factory.CreateContactsForGrouping();
            var contacsResults = contacts2
                .Where(c => c.Id == 1)
                .Select(cc => cc);

            foreach (var contact in contacsResults) {
                TestContext.WriteLine("firstName: " + contact.FirstName + ", lastname: " + contact.LastName);
                Assert.AreEqual("jorge", contact.FirstName);
            }
        }

		[TestMethod]
		public void SelectingIntoNewProjection() {
			List<Contact> contacts2 = Factory.CreateContactsForGrouping();
			var contacsResults = contacts2
				.Where(c => c.Id == 1)
				.Select(cc => new {
					FileAs = cc.FirstName + ", " + cc.LastName, 
					cc.Id,
					YearBorn = DateTime.Now.Year - cc.Age,
					cc.Age
				});

			foreach (var contact in contacsResults) {
				TestContext.WriteLine("FileAs: " + contact.FileAs + ", Id: " + contact.Id + ", Year Borned: " + contact.YearBorn + ", Age: " + contact.Age);
			}
			List<Contact> contacts = contacts2.ToList();
			Assert.AreEqual(5, contacts.Count);

		}
	}
}

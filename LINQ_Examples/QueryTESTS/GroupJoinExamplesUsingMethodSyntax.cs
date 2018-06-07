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
	public class GroupJoinExamplesUsingMethodSyntax {
        public GroupJoinExamplesUsingMethodSyntax() { }
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
		public void FilterById() {
			List<Contact> contacts2 = Factory.CreateContactsForGrouping();

			var contacsResults = from c in contacts2
								 where c.Id == 2
							     select c;

			foreach (var contact in contacsResults) {
				TestContext.WriteLine("id: " + contact.Id + ", FirstName: " + contact.FirstName + ", LastName:" + contact.LastName);
			}
			Assert.AreEqual(1, contacsResults.Count());

		}
	}
}

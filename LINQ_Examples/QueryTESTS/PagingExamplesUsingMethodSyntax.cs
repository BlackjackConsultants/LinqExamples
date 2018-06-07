using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using LING_Examples.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using LING_Examples.Entities;
using LING_Examples.Extensions;

namespace LING_Examples {
	/// <summary>
	/// Summary description for UnitTest1
	/// </summary>
	[TestClass]
	public class PagingExamplesUsingMethodSyntax {
		public PagingExamplesUsingMethodSyntax() { }
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
		public void PagingExample() {
			// create a source
			List<Contact> contactsSource = Factory.CreateContacts();
			var pageNumber = 0;
			var contactPage = contactsSource.Page(pageNumber, 15);
			while (contactPage.Count() > 0) {
				foreach (var contact in contactPage) {
					TestContext.WriteLine("id: " + contact.Id + ", FirstName: " + contact.FirstName + ", LastName:" + contact.LastName);
				}
				pageNumber++;
				contactPage = contactsSource.Page(pageNumber, 10);
			}
			Assert.AreEqual(contactPage.Count(), 0);
		}

	}
}

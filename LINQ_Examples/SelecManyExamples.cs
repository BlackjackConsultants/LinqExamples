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
	public class SelecManyExamples {
		public SelecManyExamples() {
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
		public void GettingTheOneAndManyAndMany() {
			List<Contact> contacts = Factory.CreateContacts();
			//var results = contacts.SelectMany(a => a.Addresses, (contact, address) => new { contact, address }).SelectMany(t => t.address.AddressType, (contact, address, addressType) => new { contact, address, addressType });
			var results = contacts.SelectMany(a => a.Addresses, (contact, address) => new { contact, address })
								  .SelectMany(contact => contact.address.AddressType, (contact, addressType) => new { contact, addressType });

			foreach (var item in results) {
				TestContext.WriteLine("firstName: " + item.contact.contact.FirstName + ", street: " + item.contact.address.Street + ", type: " + item.addressType.Name);
				Assert.IsNotNull(item.addressType.Name);
			}
		}

		[TestMethod]
		public void GettingTheOneAndMany() {
			List<Contact> contacts = Factory.CreateContacts();
			var results = contacts.SelectMany(a => a.Addresses, (contact, address) => new { contact, address });

			foreach (var item in results) {
				TestContext.WriteLine("firstName: " + item.contact.FirstName + " street: " + item.address.Street);
				Assert.IsNotNull(item.contact.FirstName);
				Assert.IsNotNull(item.address.Street);
			}
		}

		[TestMethod]
		public void GettingTheMany() {
			List<Contact> contacts = Factory.CreateContacts();
			var results = contacts.SelectMany(a => a.Addresses);

			foreach (var item in results) {
				TestContext.WriteLine("street: " + item.Street);
				Assert.IsNotNull(item.Street);
			}
		}
	}
}

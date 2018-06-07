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
	public class WhereExamplesUsingMethodSyntax {
		public WhereExamplesUsingMethodSyntax() { }
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

			var contacsResults = contacts2.Where(c => c.Id == 3).Select(t => t);

			foreach (var contact in contacsResults) {
				TestContext.WriteLine("id: " + contact.Id + ", FirstName: " + contact.FirstName + ", LastName:" + contact.LastName);
			}
			Assert.AreEqual(1, contacsResults.Count());

		}

		/// <summary>
		/// this is like FilterByList, but instead of using a single id, i want where in
		/// </summary>
		[TestMethod]
		public void FilterByListInParentUsingIn() {
			List<Contact> contacts2 = Factory.CreateContactsForGrouping();
			List<int> ids = new List<int>() { 1, 55 };

			var contacsResults = contacts2.Where(c => c.Addresses.Any(a => ids.Contains(a.Id))).Select(t => t);

			foreach (var contact in contacsResults) {
				TestContext.WriteLine("id: " + contact.Id + ", FirstName: " + contact.FirstName + ", LastName:" + contact.LastName);
			}
			Assert.AreEqual(3, contacsResults.Count());

		}

		/// <summary>
		/// this is like FilterByList, but instead of using a single id, i want where in
		/// </summary>
		[TestMethod]
		public void FilterByListUsingIn() {
			List<Contact> contacts2 = Factory.CreateContactsForGrouping();
			List<int> ids = new List<int>() { 1, 55 };

			var contacsResults = contacts2.Where(c => ids.Any(i => c.Id == i)).ToList();

			foreach (var contact in contacsResults) {
				TestContext.WriteLine("id: " + contact.Id + ", FirstName: " + contact.FirstName + ", LastName:" + contact.LastName);
			}
			Assert.AreEqual(1, contacsResults.Count());
		}

		/// <summary>
		/// this is like FilterByList, but instead of using a single id, i want where in
		/// </summary>
		[TestMethod]
		public void FilterByListInParentUsingNOTIn() {
			List<Contact> contacts2 = Factory.CreateContactsForGrouping();
			List<int> ids = new List<int>() { 1 };

			var contacsResults = contacts2.Where(c => !c.Addresses.Any(a => ids.Contains(a.Id))).Select(t => t);

			foreach (var contact in contacsResults) {
				TestContext.WriteLine("id: " + contact.Id + ", FirstName: " + contact.FirstName + ", LastName:" + contact.LastName);
			}
			Assert.AreEqual(4, contacsResults.Count());
		}

		/// <summary>
		/// this is like FilterByList, but instead of using a single id, i want where in
		/// </summary>
		[TestMethod]
		public void FilterByListUsingNOTIn() {
			List<Contact> contacts2 = Factory.CreateContactsForGrouping();
			List<int> ids = new List<int>() { 1, 55 };

			var contacsResults = contacts2.Where(c => !ids.Any(i => c.Id == i)).ToList();

			foreach (var contact in contacsResults) {
				TestContext.WriteLine("id: " + contact.Id + ", FirstName: " + contact.FirstName + ", LastName:" + contact.LastName);
			}
			Assert.AreEqual(4, contacsResults.Count());
		}

		[TestMethod]
        public void WhereNotInListOfStrings() {
            List<string> test1 = new List<string> { "bob", "tom" };
            List<string> test2 = new List<string> { "toss", "mary", "bob", "mike" };
            var test2NotInTest1 = test2.Where(t2 => !test1.Any(t1 => t2 == t1));
            var test2NotInTest2 = test1.Where(t2 => !test2.Any(t1 => t2 == t1));
            var list = test2NotInTest1.ToArray();
            var list2 = test2NotInTest2.ToArray();
            Assert.AreNotEqual(0, test2NotInTest1.Count());
        }
	}
}

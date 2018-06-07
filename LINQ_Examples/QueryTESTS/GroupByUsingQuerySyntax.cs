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
	public class GroupByUsingQuerySyntax {
		public GroupByUsingQuerySyntax() { }

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
		public void GroupingByMultipleProperties() {
			List<Contact> contacts = Factory.CreateContactsForGrouping();

			var query = (from c in contacts
						 group c by new { c.FirstName, c.LastName }
							 into grp
							 select new {
								 grp.Key.FirstName,
								 grp.Key.LastName,
								 Count = grp.Count()
							 });
			var contactList = query.ToList();
			Assert.AreEqual(contactList[2].Count, 2);
		}

		[TestMethod]
		public void GroupingByToGetCount() {
			List<Contact> contacts = Factory.CreateContactsForGrouping();

			var query = (from c in contacts
						 group c by new { c.FirstName, c.LastName }
							 into grp
							 select new {
								 grp.Key.FirstName,
								 Count = grp.Count()
							 });
			var contactList = query.ToList();
			Assert.AreEqual(contactList[2].Count, 2);
		}


		[TestMethod]
		public void GroupingByToGetAmount() {
			List<Contact> contacts = Factory.CreateContactsForGrouping();

			var query = (from c in contacts
						 group c by new { c.FirstName }
							 into grp
							 select new {
								 grp.Key.FirstName,
								 Sum = grp.Sum(c => c.Salary)
							 });
			var contactList = query.ToList();
			Assert.AreEqual(contactList[2].Sum, 52222);
		}
	}
}

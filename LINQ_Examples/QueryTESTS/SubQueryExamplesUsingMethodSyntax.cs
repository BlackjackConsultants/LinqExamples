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
	public class SubQueryExamplesUsingMethodSyntax {
		public SubQueryExamplesUsingMethodSyntax() { }

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
		/// in this case you have to list who share a property like contact.id, this they dont share a property, then you have to get the list of ids of the Many
        /// list, for example addresses, and then get all contacts where in the list of ids.  see FilterByListUsingIn method
		/// </summary>
        [TestMethod]
        public void UsingAnyWith2Lists() {
            var contacts1 = new List<Contact>() {
	            new Contact() { FirstName = "jorge1", LastName = "perez1", Id = 1 }, 
				new Contact() { FirstName = "jorge2", LastName = "perez2", Id = 2 },
				new Contact() { FirstName = "jorge5", LastName = "perez5", Id = 5 },
				new Contact() { FirstName = "jorge6", LastName = "perez6", Id = 6 }
            };
            var contacts2 = new List<Contact>() {
	            new Contact() { FirstName = "jorge1", LastName = "perez1", Id = 1 }, 
				new Contact() { FirstName = "jorge2", LastName = "perez2", Id = 2 },
				new Contact() { FirstName = "jorge3", LastName = "perez3", Id = 3 },
				new Contact() { FirstName = "jorge4", LastName = "perez4", Id = 4 }
            };
			var contacsResults = contacts2.Where(t2 => contacts1.Any(t1 => t2.Id == t1.Id));
			foreach (var contact in contacsResults) {
				TestContext.WriteLine("id: " + contact.Id + ", FirstName: " + contact.FirstName + ", LastName:" + contact.LastName);
	        }
			Assert.AreEqual(2, contacsResults.Count());
        }


		/// <summary>
		/// in this case you have to list who share a property
		/// </summary>
		[TestMethod]
		public void UsingContainsWith2Levels() {
			// List<int> addressIds = new List<int>() { 2, 3, 4 };
			// var contacts2 = Factory.CreateContactsForGrouping();
			//var contacts2 = new List<Contact>() {
			//	new Contact() { FirstName = "jorge1", LastName = "perez1", Id = 1 }, 
			//	new Contact() { FirstName = "jorge2", LastName = "perez2", Id = 2 },
			//	new Contact() { FirstName = "jorge3", LastName = "perez3", Id = 3 },
			//	new Contact() { FirstName = "jorge4", LastName = "perez4", Id = 4 }
			//};

			// var contacsResults = contacts2.Where(c => c.Addresses.Any(a => a.Id == addressIds));
			//foreach (var contact in contacsResults) {
			//	TestContext.WriteLine("id: " + contact.Id + ", FirstName: " + contact.FirstName + ", LastName:" + contact.LastName);
			//}
			//Assert.AreEqual(3, contacsResults.Count());

		}


        /// <summary>
        /// this is like FilterByList, but instead of using a single id, i want WHERE IN
        /// </summary>
        [TestMethod]
        public void SubQueryUsingAnyInIdList() {
            List<Contact> contacts2 = Factory.CreateContactsForGrouping();
            List<int> ids = new List<int>() { 1 };

            var contacsResults = contacts2.Where(c => c.Addresses.Any(a => ids.Contains(a.Id))).Select(t => t);

            foreach (var contact in contacsResults) {
                TestContext.WriteLine("id: " + contact.Id + ", FirstName: " + contact.FirstName + ", LastName:" + contact.LastName);
            }
            Assert.AreEqual(1, contacsResults.Count());

            // NOTE THAT YOU CAN DO SAME QUERY WITHOUT USING SUBQUERY.  IF EACH ADDRESS HAS A POINTER TO THE PARENT.  SEE FINDWITHOUTSUBQUERY.
        }

        /// <summary>
        /// if the object in example  SubQueryUsingAnyInIdList has a parent property that points to parent, then you dont need to use subquery, you start from address where
        /// parent id is...
        /// </summary>
        [TestMethod]
        public void SubQueryAlternativeUsingParentPropertyInsteadOfSubquery() {
            List<USAddress> addresses = Factory.CreateAddresses();

            var results = addresses.Where(a => a.Parent.Id == 1);

            foreach (var address in results) {
                TestContext.WriteLine("id: " + address.Parent.Id + ", FirstName: " + address.Parent.FirstName + ", LastName:" + address.Parent.LastName);
            }
            Assert.AreEqual(2, results.Count());
        }

        /////// <summary>
        /////// this is like FilterByList, but instead of using a single id, i want where in
        /////// </summary>
        ////[TestMethod]
        ////public void FilterByListUsingNOTIn() {
        ////    List<Contact> contacts2 = Factory.CreateContactsForGrouping();
        ////    List<int> ids = new List<int>() { 1 };

        ////    var contacsResults = contacts2.Where(c => c.Addresses.Any(a => !ids.Contains(a.Id))).Select(t => t);

        ////    foreach (var contact in contacsResults) {
        ////        TestContext.WriteLine("id: " + contact.Id + ", FirstName: " + contact.FirstName + ", LastName:" + contact.LastName);
        ////    }
        ////    Assert.AreEqual(3, contacsResults.Count());

        ////}

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

        ////[TestMethod]
        ////public void WhereItemListHasItems() {
        ////    List<Contact> contacts2 = Factory.CreateContactsForGrouping();
        ////    var contacsResults = contacts2
        ////                    .Where(c => c.Addresses.Any());
        ////    Assert.AreEqual(3, contacsResults.Count());
        ////}

        ////[TestMethod]
        ////public void WhereItemListHasNoItems() {
        ////    List<Contact> contacts2 = Factory.CreateContactsForGrouping();
        ////    var contacsResults = contacts2
        ////                    .Where(c => !c.Addresses.Any());
        ////    Assert.AreEqual(2, contacsResults.Count());
        ////}

		[TestMethod]
		public void WhereItemListHasItemWithId() {
			List<Contact> contacts2 = Factory.CreateContactsForGrouping();
			var contacsResults = contacts2
							.Where(c => c.Addresses.Any(a => a.Id == 55));
			foreach (var contacsResult in contacsResults) {
				TestContext.WriteLine(contacsResult.Id + ", " + contacsResult.FirstName);
				foreach (var adress in contacsResult.Addresses) {
					TestContext.WriteLine(adress.Id + ", " + adress.Street);
						
				}
			}
			Assert.AreEqual(2, contacsResults.Count());
		}

		[TestMethod]
		public void WhereItemListHasItemOfAType() {
			List<Contact> contacts2 = Factory.CreateContactsForGrouping();
			var contacsResults = contacts2
							.Where(c => c.Addresses.Any(a => a is CubanAddress));
			var results = contacsResults.ToList();
			Assert.AreEqual(1, contacsResults.Count());
		}

		[TestMethod]
		public void WhereItemListHasItemOfATypeAndValue() {
			List<Contact> contacts2 = Factory.CreateContactsForGrouping();
			var contacsResults = contacts2
							.Where(c => c.Addresses.Any(a => a is USAddress && ((USAddress)a).ZipCode == "32165"));
			var results = contacsResults.ToList();
			Assert.AreEqual(1, contacsResults.Count());
		}
    }
}

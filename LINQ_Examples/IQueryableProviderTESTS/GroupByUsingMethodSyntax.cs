using System.Collections.Generic;
using System.Linq;
using LING_Examples.Entities;
using LING_Examples.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LING_Examples.IQueryableProviderTESTS {
	/// <summary>
	/// Summary description for UnitTest1
	/// </summary>
	[TestClass]
	public class IQueryableExamples {

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
		public void GroupingMultipleColumns() {
            List<Contact> contacts2 = Factory.CreateContactsForGrouping();
            var contacsResults = contacts2
                .GroupBy(cg => new {cg.Age,  cg.LastName},
                (key, group ) => new {
                    age = key.Age,
                    lastName = key.LastName,
                    Count = group.Count()
                })
                .Select(cs => cs);

            foreach (var contact in contacsResults) {
                TestContext.WriteLine("LastName: " + contact.lastName + ", age: " + contact.age + ", last name count for this age count: " + contact.Count);
            }
            Assert.AreEqual(3, contacsResults.Count());
		}

        [TestMethod]
        public void GroupingBySingleColumn() {
            List<Contact> contacts2 = Factory.CreateContactsForGrouping();
            var contacsResults = contacts2
                .GroupBy(cg => new { cg.Age },
                (key, group) => new {
                    age = key.Age,
                    Count = group.Count()
                })
                .Select(cs => cs);

            foreach (var contact in contacsResults) {
                TestContext.WriteLine("age: " + contact.age);
            }
            Assert.AreEqual(2, contacsResults.Count());

        }
	}
}

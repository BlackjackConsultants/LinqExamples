
using System.Collections.Generic;
using System.Linq;
using LING_Examples.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LING_Examples.Entities;

namespace LING_Examples {
	/// <summary>
	/// Summary description for UnitTest1
	/// </summary>
	[TestClass]
	public class AggregateFunctionsByExamples {
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

        ////[TestMethod]
        ////public void Sums() {
        ////    List<Contact> contacts2 = Factory.CreateContactsForGrouping();
        ////    var contacsResults = contacts2.Sum(contact => contact.Salary);
        ////    TestContext.WriteLine("results: " +contacsResults);
        ////    Assert.AreEqual(93333.0, contacsResults);
        ////}

	}
}

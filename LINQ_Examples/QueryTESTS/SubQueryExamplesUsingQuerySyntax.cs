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
    public class LinqMethodSyntaxQueryOneToManyCollectionShould {
        public LinqMethodSyntaxQueryOneToManyCollectionShould() {
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

		/// <summary>
		/// this is equivalent to contacs.addresses.any(a => a.city == 'miami')
		/// </summary>
		[TestMethod]
		public void UsingContainsWith2Levels() {
			List<Contact> contacts2 = Factory.CreateContactsForGrouping();

			var contacsResults = from c in contacts2
								 from a in c.Addresses
								 where a.City.ToLower() == "hialeah"
								 select c;

			foreach (var contacsResult in contacsResults) {
				TestContext.WriteLine(contacsResult.Id + ", " + contacsResult.FirstName);
				foreach (var adress in contacsResult.Addresses) {
					TestContext.WriteLine(adress.Id + ", " + adress.City);
				}
			}
			Assert.AreEqual(1, contacsResults.Count());
		}
    }
}

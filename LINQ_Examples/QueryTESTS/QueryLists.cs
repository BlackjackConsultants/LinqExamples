﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using LING_Examples.Entities;
using LING_Examples.Factories;

namespace LING_Examples {
	/// <summary>
	/// Summary description for UnitTest1
	/// </summary>
	[TestClass]
	public class QueryLists {
		public QueryLists() {
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
		public void QueryListUsingExplicitSyntax() {
			string[] names = { "Burke", "Connor", "Frank", "Everett", "Albert", "George", "Harris", "David" };

			IEnumerable<string> query = names.Where(s => s.Length == 5)
											 .OrderBy(s => s)
											 .Select(s => s.ToUpper());
			foreach (string item in query)
				TestContext.WriteLine(item);

			Assert.IsTrue(query.ToList<string>().Count == 3);

		}
		[TestMethod]
		public void QueryListUsingQueryExpressions() {
			string[] names = { "Burke", "Connor", "Frank", "Everett", "Albert", "George", "Harris", "David" };

			IEnumerable<string> query = from s in names
										where s.Length == 5
										orderby s
										select s.ToUpper();
			
			foreach (string item in query)
				TestContext.WriteLine(item);
			Assert.IsTrue(query.ToList<string>().Count == 3);

		}
		[TestMethod]
		public void ReturnAListItemUsingQueryWhenWhereClauseUsesItemsProperty() {


		}




	}
}

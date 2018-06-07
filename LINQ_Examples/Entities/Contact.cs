using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LING_Examples.Entities {
	public class Contact {
		public Contact() {
			Phones = new List<Phone>();
			Addresses = new List<AddressBase>();
		}
		public string FirstName {
			get;
			set;
		}
		public string LastName {
			get;
			set;
		}
		public List<Phone> Phones {
			get;
			set;
		}
		public int Age {
			get;
			set;
		}
		public List<AddressBase> Addresses {
			get;
			set;
		}
		public int Id {
			get;
			set;
		}
        public Contact Father { get; set; }

		public decimal Salary { get; set; }
	}
}

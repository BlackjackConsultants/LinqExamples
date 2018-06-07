using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LING_Examples.Entities {
	public class AddressBase {
		private new List<AddressType> addressType;
		public int Id {
			get;
			set;
		}

		public string Country {
			get;
			set;
		}

        public Contact Parent {
            get;
            set;
        }

		public string Street {
			get;
			set;
		}

		public string City {
			get;
			set;
		}

		public List<AddressType> AddressType {
			get {
				if (addressType == null) {
					addressType = new List<AddressType>();
				}
				return addressType;
			}
		}
	}
}

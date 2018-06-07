using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using LING_Examples.Entities;

namespace LING_Examples.Factories {
	public class Factory {
		public static List<Contact> CreateContactsLazy() {
			var contacts = new List<Contact>();
			for (int i = 0; i < 100; i++) {
				var contact = new Contact();
				contact.LastName = "Perez" + i.ToString(CultureInfo.InvariantCulture);
				contact.FirstName = "Jorge" + i.ToString(CultureInfo.InvariantCulture);
				contact.Id = i;
				contacts.Add(contact);
			}
			return contacts;
		}

		public static List<Phone> CreatePhonesLazy() {
			var phones = new List<Phone>();
			for (int i = 0; i < 100; i++) {
				var phone = new Phone { Number = "111-111" + i.ToString(CultureInfo.InvariantCulture), Type = "Home" + i.ToString(CultureInfo.InvariantCulture), Id = i };
				phones.Add(phone);
			}
			return phones;
		}

		public static List<AddressBase> CreateAddressesLazy() {
			var addresses = new List<AddressBase>();
			for (int i = 0; i < 100; i++) {
				string iStr = i.ToString();
				var address = new AddressBase() { City = "Miami" + iStr, Country = "USA" };
				addresses.Add(address);
			}
			return addresses;
		}

		public static List<Contact> CreateContacts() {
			List<Contact> contacts = new List<Contact>();
			for (int i = 0; i < 100; i++) {
				Contact contact = new Contact();
				contact.LastName = "Perez" + i.ToString(CultureInfo.InvariantCulture);
				contact.FirstName = "Jorge" + i.ToString(CultureInfo.InvariantCulture);
				contact.Id = i;
				contact.Father = new Contact() { FirstName = "Frank", LastName = "Perez", Age = 67 };
				// create phones
				for (int j = 0; j < 3; j++) {
					Phone phone = new Phone();
					phone.Number = "111-111" + j.ToString(CultureInfo.InvariantCulture);
					contact.Phones.Add(phone);
				}
				// create addresses
				for (int j = 0; j < 4; j++) {
					string zip = string.Empty;
					if (contact.LastName.EndsWith("1"))
						zip = "1111" + j.ToString(CultureInfo.InvariantCulture);
					else {
						zip = "2222" + j.ToString(CultureInfo.InvariantCulture);
					}
					USAddress address = new USAddress();
					address.Street = "100 nw 133" + j.ToString(CultureInfo.InvariantCulture);
					address.ZipCode = zip;
					address.City = "Miami" + j.ToString(CultureInfo.InvariantCulture);
					address.Country = "USA" + j.ToString();
					address.Parent = contact;
					for (int k = 0; k < 5; k++) {
						AddressType addressType = new AddressType();
						addressType.Id = k.ToString();
						addressType.Name = "type" + k.ToString();
						address.AddressType.Add(addressType);
					}
					contact.Addresses.Add(address);
				}
				contacts.Add(contact);
			}
			return contacts;
		}

		public static List<Contact> CreateContactsForGrouping() {
			List<Contact> contacts = new List<Contact>();
			// contact 1
			Contact contact = new Contact { FirstName = "jorge", LastName = "perez", Id = 1, Age = 14, Salary = 20000 };
			contacts.Add(contact);
			CubanAddress address0 = new CubanAddress { Street = "1000 nw 136 ave", City = "Miami", Id = 2, Country = "USA", Parent = contact };
			CubanAddress address1 = new CubanAddress { Street = "222 nw 222 ave", City = "Miami", Id = 11, Country = "USA", Parent = contact };
			contact.Addresses.Add(address0);
			contact.Addresses.Add(address1);
			// contact 2
			Contact contact2 = new Contact { FirstName = "jorge2", LastName = "perez3", Id = 2, Age = 15, Salary = 10000 };
			contacts.Add(contact2);
			USAddress address2 = new USAddress { Street = "1000 nw 136 ave", City = "Miami", Id = 1, Country = "USA", ZipCode = "33333", Parent = contact2 };
			USAddress address3 = new USAddress { Street = "222 nw 222 ave", City = "Miami", Id = 5, Country = "USA", ZipCode = "33282", Parent = contact2 };
			contact2.Addresses.Add(address2);
			contact2.Addresses.Add(address3);
			// contact 3
			Contact contact3 = new Contact { FirstName = "jorge3", LastName = "perez3", Id = 3, Age = 14, Salary = 30000 };
			contacts.Add(contact3);
			USAddress address4 = new USAddress { Street = "1000 nw 136 ave", City = "Miami", Id = 55, Country = "USA", ZipCode = "33333", Parent = contact3 };
			USAddress address5 = new USAddress { Street = "222 nw 222 ave", City = "Miami", Id = 3, Country = "USA", ZipCode = "33282", Parent = contact3 };
			contact3.Addresses.Add(address4);
			contact3.Addresses.Add(address5);
			// contact 4
			Contact contact4 = new Contact { FirstName = "jorge4", LastName = "perez3", Id = 4, Age = 15, Salary = 11111 };
			contacts.Add(contact4);
			USAddress address6 = new USAddress { Street = "1000 nw 136 ave", City = "Miami", Id = 55, Country = "USA", ZipCode = "33333", Parent = contact4 };
			USAddress address7 = new USAddress { Street = "222 nw 222 ave", City = "Miami", Id = 3, Country = "USA", ZipCode = "33282", Parent = contact4 };
			contact4.Addresses.Add(address4);
			contact4.Addresses.Add(address5);
			// contact 5
			Contact contact5 = new Contact { FirstName = "jorge3", LastName = "perez3", Id = 4, Age = 15, Salary = 22222 };
			contacts.Add(contact5);
			USAddress address8 = new USAddress { Street = "1000 nw 136 ave", City = "Hialeah", Id = 55, Country = "USA", ZipCode = "32165", Parent = contact5 };
			USAddress address9 = new USAddress { Street = "222 nw 222 ave", City = "Miami", Id = 3, Country = "USA", ZipCode = "33282", Parent = contact5 };
			contact3.Addresses.Add(address8);
			contact3.Addresses.Add(address9);

			//return list
			return contacts;
		}

		public static List<USAddress> CreateAddresses() {
			List<USAddress> addressesList = new List<USAddress>();
			List<Contact> contacts = new List<Contact>();
			// contact 1
			Contact contact = new Contact { FirstName = "jorge", LastName = "perez", Id = 1 };
			contacts.Add(contact);
			USAddress address0 = new USAddress { Street = "1000 nw 136 ave", City = "Miami", Id = 2, Country = "USA", ZipCode = "33283", Parent = contact };
			USAddress address1 = new USAddress { Street = "222 nw 222 ave", City = "Miami", Id = 11, Country = "USA", ZipCode = "33282", Parent = contact };
			contact.Addresses.Add(address0);
			contact.Addresses.Add(address1);
			addressesList.Add(address0);
			addressesList.Add(address1);
			// contact 2
			Contact contact2 = new Contact { FirstName = "jorge2", LastName = "perez2", Id = 2 };
			contacts.Add(contact2);
			USAddress address2 = new USAddress { Street = "1000 nw 136 ave", City = "Miami", Id = 1, Country = "USA", ZipCode = "33333", Parent = contact2 };
			USAddress address3 = new USAddress { Street = "222 nw 222 ave", City = "Miami", Id = 5, Country = "USA", ZipCode = "33282", Parent = contact2 };
			contact2.Addresses.Add(address2);
			contact2.Addresses.Add(address3);
			addressesList.Add(address2);
			addressesList.Add(address3);
			// contact 3
			Contact contact3 = new Contact { FirstName = "jorge3", LastName = "perez3", Id = 3 };
			contacts.Add(contact3);
			USAddress address4 = new USAddress { Street = "1000 nw 136 ave", City = "Miami", Id = 55, Country = "USA", ZipCode = "33333", Parent = contact3 };
			USAddress address5 = new USAddress { Street = "222 nw 222 ave", City = "Miami", Id = 3, Country = "USA", ZipCode = "33282", Parent = contact3 };
			contact3.Addresses.Add(address4);
			contact3.Addresses.Add(address5);
			addressesList.Add(address4);
			addressesList.Add(address5);
			return addressesList;
		}
	}
}

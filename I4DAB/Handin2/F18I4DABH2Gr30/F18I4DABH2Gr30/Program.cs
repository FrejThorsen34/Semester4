using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F18I4DABH2Gr30
{
	class Program
	{
		static void Main(string[] args)
		{
            PersonKartotek mitKartotek = new PersonKartotek();
            ZIPList ziplist = new ZIPList();
            Email email = new Email("Nickolai@email.dk");
            PhoneNumber phone1 = new PhoneNumber(22334455, "Private", "Telia");
		    PhoneNumber phone2 = new PhoneNumber(11001100, "Workphone", "TDC");
            ZIP aarhus = new ZIP("8000", "Denmark", "Jylland", "Aarhus");
            ZIP odense = new ZIP("5000", "Denmark", "Fyn", "Odense");
            Address address1 = new Address("Private", "Vestre Ringgade", 10, 3, aarhus);
		    Address address2 = new Address("Work", "Finlandsgade", 17, 1, aarhus);
            Address address3 = new Address("Cottage", "Vollsmosegade", 1, 1, odense);
            Person person1 = new Person("Nickolai", "Lundby", "Ernst", 130188, "Cool");
            person1.SetAddress(address1);
            person1.SetAddress(address2);
            person1.SetAddress(address3);
            person1.SetPhoneNumber(phone1);
		    person1.SetPhoneNumber(phone2);
            person1.SetEmail(email);

		    mitKartotek.AddPerson(person1);
            mitKartotek.PrintPersonKartotek();
		    Console.ReadLine();
		}
	}
}

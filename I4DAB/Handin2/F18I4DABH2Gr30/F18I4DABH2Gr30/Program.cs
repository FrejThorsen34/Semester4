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
            #region Setup
            PersonKartotek mitKartotek = new PersonKartotek();
            ZIPList ziplist = new ZIPList();
		    ZIP aarhus = new ZIP("8000", "Denmark", "Jylland", "Aarhus");
		    ZIP odense = new ZIP("5000", "Denmark", "Fyn", "Odense");
		    ZIP hongkong = new ZIP("518003", "China", "Hong Kong", "Hong Kong");
            #endregion

            #region Person1
            Email email = new Email("Nickolai@email.dk");
            PhoneNumber phone1 = new PhoneNumber(22334455, "Private", "Telia");
		    PhoneNumber phone2 = new PhoneNumber(11001100, "Workphone", "TDC");
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
            #endregion

            #region Person2
            Email email2 = new Email("Stanie@email.dk");
		    PhoneNumber phone3 = new PhoneNumber(88888888, "Private", "Telia");
		    PhoneNumber phone4 = new PhoneNumber(44444444, "Workphone", "TDC");
		    Address address4 = new Address("Private", "Fynsgade", 4, 8, aarhus);
		    Address address5 = new Address("Work", "Norges Alle", 11, 3, aarhus);
		    Address address6 = new Address("Cottage", "Main Street", 13, 2, hongkong);
		    Person person2 = new Person("Stanie", "", "Cheung", 220296, "Chill");
		    person2.SetAddress(address4);
		    person2.SetAddress(address5);
		    person2.SetAddress(address6);
		    person2.SetPhoneNumber(phone3);
		    person2.SetPhoneNumber(phone4);
		    person2.SetEmail(email2);
            #endregion

            mitKartotek.AddPerson(person1);
            mitKartotek.AddPerson(person2);
            mitKartotek.PrintPersonKartotek();
		    Console.ReadLine();
		}
	}
}

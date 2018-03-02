using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F18I4DABH2Gr30
{
	public class PersonKartotek
	{
		private List<Person> _persons;

	    public PersonKartotek()
	    {
            _persons = new List<Person>();
	    }

	    public void AddPerson(Person person)
	    {
	        _persons.Add(person);
	    }

	    public void PrintPersonKartotek()
	    {
	        foreach (var p in _persons)
	        {	            
                Console.WriteLine($"First name  : {p.FirstName}");
	            Console.WriteLine($"Middle name : {p.MiddleName}");
	            Console.WriteLine($"Last name   : {p.LastName}");
                Console.WriteLine($"Person ID   : {p.PersonId}");
                Console.WriteLine($"Persontype  : {p.PersonType}");
	            var temp = p.GetAddress();
                Console.WriteLine($"Number of addresses: {temp.Count}");
	            foreach (var add in temp)
	            {
                    Console.WriteLine($"Addresstype: {add.GetAddressType}");
	                Console.WriteLine($"Full address: {add.GetStreet}, {add.GetStreetNo}, {add.GetApartmentNo}");
	                var temp2 = add.GetZIP;
                    Console.WriteLine($"Full address: {temp2.Country}, {temp2.State}, {temp2.Town}, {temp2.ZipCode}");
                }
            }
	    }
	}
}

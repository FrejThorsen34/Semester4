using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Del2.Models
{
	public class PrimaryAddressDTO
	{
		public PrimaryAddressDTO(){}

		public PrimaryAddressDTO(PrimaryAddress primaryAddress)
		{
			Id = primaryAddress.Id;
			Street = primaryAddress.Street;
			StreetNumber = primaryAddress.StreetNumber;
			Zip = new ZipDTO(primaryAddress.Zip);
		}

		public PrimaryAddress ToPrimaryAddress()
		{
			return new PrimaryAddress()
			{
				Id = Id,
				Street = Street,
				StreetNumber = StreetNumber,
				Zip = Zip.ToZip(),
				ZipId = Zip.Id
			};
		}
		public int Id { get; set; }
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public ZipDTO Zip { get; set; }
	}
}
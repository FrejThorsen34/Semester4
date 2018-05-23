using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGridInfo.Models
{
	public class ConnectionDTO
	{
		public ConnectionDTO(){}

		public ConnectionDTO(Connection connection)
		{
			Id = connection.Id;
			Distance = connection.Distance;
			SmartMeters = new List<string>();
			foreach (var sm in connection.SmartMeters)
			{
				SmartMeters.Add(sm.SerialNumber);
			}
			
		}

		public string Id { get; set; }
		public List<string> SmartMeters { get; set; }
		public double Distance { get; set; }
	}
}
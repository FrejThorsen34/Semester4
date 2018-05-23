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
			SmartMeters = new List<SmartMeter>();
			
		}

		public string Id { get; set; }
		public List<SmartMeter> SmartMeters { get; set; }
		public double Distance { get; set; }
	}
}
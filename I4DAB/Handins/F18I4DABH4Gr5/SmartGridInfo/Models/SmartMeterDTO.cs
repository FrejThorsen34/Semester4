using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGridInfo.Models
{
	public class SmartMeterDTO
	{
		public SmartMeterDTO(){}

		public SmartMeterDTO(SmartMeter smartMeter)
		{
			SerialNumber = smartMeter.SerialNumber;
			ProsumerId = smartMeter.ProsumerId;
			Connections = new List<string>();
			foreach (var c in smartMeter.Connections)
			{
				Connections.Add(c.Id);
			}

		}

		public string SerialNumber { get; set; }
		public string ProsumerId { get; set; }
		public List<string> Connections { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraderInfo.Models
{
	public class FutureTrade
	{
		public string Id { get; set; }
		public string ProsumerId { get; set; }
		public string Type { get; set; }
		public double Tokens { get; set; }
		//nødvendig???
		public double ExchangeRate { get; set; }
	}
}
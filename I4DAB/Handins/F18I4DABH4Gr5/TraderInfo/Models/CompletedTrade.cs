using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TraderInfo.Models
{
	public class CompletedTrade
	{
	    [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }
	    [JsonProperty(PropertyName = "ProsumerId", Required = Required.Always)]
        public string ProsumerId { get; set; }
	    [JsonProperty(PropertyName = "Type", Required = Required.Always)]
        public string Type { get; set; }
	    [JsonProperty(PropertyName = "Tokens", Required = Required.Always)]
        public double Tokens { get; set; }
	    [JsonProperty(PropertyName = "Exchangerate", Required = Required.AllowNull)]
        public double ExchangeRate { get; set; }

	    public override string ToString()
	    {
	        return JsonConvert.SerializeObject(this);
	    }
    }
}
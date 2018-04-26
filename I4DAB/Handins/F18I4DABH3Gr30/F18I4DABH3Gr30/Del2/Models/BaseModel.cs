using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Del2.Models
{
	public class BaseModel
	{
		[DataMember]
		public int Id { get; set; }
	}
}
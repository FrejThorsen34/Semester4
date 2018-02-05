using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HullSpeed
{
	class SailBoat
	{
		public string Name { get; set; }
		
		public double Length { get; set; }

		public double Hullspeed()
		{
			return 1.34 * System.Math.Sqrt(Length);
		}
	}
}

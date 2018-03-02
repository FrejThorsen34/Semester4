using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F18I4DABH2Gr30
{
	public class ZIPList
	{
		public static List<ZIP> _zips;

		public ZIPList()
		{
			_zips = new List<ZIP>();
		}

		public static int LookUp(ZIP zip)
		{
		    if (_zips.Count == 0)
		    {
		        AddZip(zip);
		        return _zips.Count - 1;
		    }
		    bool isThere = _zips.Contains(zip);
			if (!isThere)
			{
				AddZip(zip);
			}
			else
			{
				return _zips.IndexOf(zip);
			}

			return _zips.Count - 1;
		}

		private static void AddZip(ZIP zip)
		{
			_zips.Add(zip);
		}

	}
}

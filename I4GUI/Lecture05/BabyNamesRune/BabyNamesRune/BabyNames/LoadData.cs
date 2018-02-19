using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyNames
{
	public class LoadData
	{
		public static List<BabyName> ReadBabyNameData(string filename)
		{
			string input;
			List<BabyName> names = new List<BabyName>();

			using (System.IO.StreamReader reader = new System.IO.StreamReader(filename))
			{
				input = reader.ReadLine();
				while (input != null)
				{
					names.Add(new BabyName(input));
					input = reader.ReadLine();
				}
			}

			return names;
		}
	}
}

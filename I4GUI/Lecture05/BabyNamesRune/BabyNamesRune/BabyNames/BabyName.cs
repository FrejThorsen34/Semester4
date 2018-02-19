using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyNames
{
	class BabyName
	{
		private string _name;
		private int[] _ranks;

		public string Name
		{
			get { return _name; }
		}

		public BabyName(string nameAndRankings)
		{
			string[] tokens;
			char[] seperators = {' '};

			tokens = nameAndRankings.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
			this._name = tokens[0];
			this._ranks = new int[10];
			for (int i = 0; i < 10; i++)
			{
				this._ranks[i] = int.Parse(tokens[i + 1]);
			}
		}

		public int Rank(int year)
		{
			int index = (year - 1900) / 10;
			if (index < 0 || index > 10)
			{
				throw new SystemException("Year must be 1900, 1910 ... 2000");
			}

			return this._ranks[index];
		}

		public int AverageRank()
		{
			int sum = 0;

			for (int i = 0; i < this._ranks.Length; i++)
			{
				if (this._ranks[i] == 0)
					sum += 2500;
				else
					sum += this._ranks[i];
			}

			return sum / this._ranks.Length;
		}
	}
}

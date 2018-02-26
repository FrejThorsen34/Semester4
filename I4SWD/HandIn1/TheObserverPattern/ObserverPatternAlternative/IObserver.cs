using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//
//	Group 25									//
//	NE84070 - Nickolai Lundby Ernst				//
//	20105809 - Rune Aagaard Keena				//
//												//
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//

namespace ObserverPatternAlternative
{
	public interface IObserver<T>
	{
		void Update(T subjectType);
	}
}

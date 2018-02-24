using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternAlternative
{
	public interface IObserver<T>
	{
		void Update(T subjectType);
	}
}

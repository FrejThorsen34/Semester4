using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternAlternative
{
    public abstract class SubjectType<T>
    {
	    private List<IObserver<T>> _observers = new List<IObserver<T>>();

		public void Attach(IObserver<T> observer)
	    {
		    _observers.Add(observer);
	    }

	    public void Detach(IObserver<T> observer)
	    {
		    _observers.Remove(observer);

	    }

	    public void Notify(T subject)
	    {
			foreach (var o in _observers)
			{
				o.Update(subject);
			}
		}
	}
}

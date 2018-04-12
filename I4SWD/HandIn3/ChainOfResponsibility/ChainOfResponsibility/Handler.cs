using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public abstract class Handler
    {
	    protected Handler _nextHandler;

	    public void SetNextHandler(Handler next)
	    {
		    this._nextHandler = next;
	    }

	    public abstract void HandleRequest(Request request);
    }
}

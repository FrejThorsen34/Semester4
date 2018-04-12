using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public abstract class Handler
    {
	    protected Handler NextHandler;

	    public void SetNextHandler(Handler next)
	    {
		    this.NextHandler = next;
	    }

	    public abstract void HandleRequest(Request request);
    }
}

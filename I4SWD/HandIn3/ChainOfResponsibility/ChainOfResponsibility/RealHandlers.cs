using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
	public class NegativeHandler : Handler
	{
		public override void HandleRequest(Request request)
		{
			if (request.Value < 0)
			{
				Console.WriteLine($"{request.Name} handled by NegativeHandler - Value: {request.Value}");
			}
			else if(_nextHandler != null)
			{
				_nextHandler.HandleRequest(request);
			}
		}
	}

	public class ZeroHandler : Handler
	{
		public override void HandleRequest(Request request)
		{
			if (request.Value == 0)
			{
				Console.WriteLine($"{request.Name} handled by ZeroHandler - Value: {request.Value}");
			}
			else if (_nextHandler != null)
			{
				_nextHandler.HandleRequest(request);
			}
		}
	}

	public class PositiveHandler : Handler
	{
		public override void HandleRequest(Request request)
		{
			if (request.Value > 0)
			{
				Console.WriteLine($"{request.Name} handled by PositiveHandler - Value: {request.Value}");
			}
			else if (_nextHandler != null)
			{
				_nextHandler.HandleRequest(request);
			}
		}
	}
}

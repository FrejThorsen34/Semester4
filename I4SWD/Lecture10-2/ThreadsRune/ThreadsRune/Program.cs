using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsRune
{
	class Program
	{
		static void Main(string[] args)
		{
			HelloWriter1 writerA = new HelloWriter1("Writer A");
			HelloWriter2 writerB = new HelloWriter2("Writer B", 20);
			//HelloWriter3 writerC = new HelloWriter3("Writer C");

			writerA.NumberOfTimesToLoop = 10;

			Thread threadA = new Thread(writerA.SayHello);
			Thread threadB = new Thread(writerB.SayHello);
			//Thread threadC = new Thread(writerC.SayHello);

			Thread NeverEndingStoryThread = new Thread(NeverEndingWork);
			//NeverEndingStoryThread.IsBackground = true;
			NeverEndingStoryThread.Start();

			threadA.Start();
			threadB.Start();
			//threadC.Start(30);

			threadA.Join();
			threadB.Join();
			Console.WriteLine("Hello from main");
			Console.ReadKey();
		}

		static void NeverEndingWork()
		{
			while ()
			{
				Console.WriteLine("Never ending story");
				Thread.Sleep(new TimeSpan(0,0,0,5));
			}
		}
	}

	class HelloWriter1
	{
		public string Name { get; private set; }
		public int NumberOfTimesToLoop { get; set; }

		public HelloWriter1(string name)
		{
			Name = name;
		}

		public void SayHello()
		{
			for (int i = 1; i <= NumberOfTimesToLoop; i++)
			{
				Console.WriteLine($"Hello from {Name} #{i}");
				Thread.Sleep(500);
			}
		}
	}

	class HelloWriter2
	{
		public string Name { get; private set; }
		private int _numberOfTimesToLoop;

		public HelloWriter2(string name, int numberOfTimesToLoop)
		{
			Name = name;
			_numberOfTimesToLoop = numberOfTimesToLoop;
		}

		public void SayHello()
		{
			for (int i = 1; i <= _numberOfTimesToLoop; i++)
			{
				Console.WriteLine($"Hello from {Name} #{i}");
				Thread.Sleep(200);
			}
		}
	}

	class HelloWriter3
	{
		public string Name { get; private set; }

		public HelloWriter3(string name)
		{
			Name = name;
		}

		public void SayHello(object numberOfTimesToLoopObject)
		{
			int numberOfTimesToLoop = (int) numberOfTimesToLoopObject;
			for (int i = 1; i <= numberOfTimesToLoop; i++)
			{
				Console.WriteLine($"Hello from {Name} #{i}");
			}
		}
	}
}

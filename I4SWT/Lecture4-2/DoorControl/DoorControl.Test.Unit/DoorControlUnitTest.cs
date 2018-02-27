using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace DoorControl.Test.Unit
{
	[TestFixture]
	[Author("Gruppe 35")]
    public class DoorControlUnitTest
	{
		private DoorControl _uut;
		private IDoor _door = Substitute.For<IDoor>();
		private IUserValidation _userValidation = Substitute.For<IUserValidation>();
		private IEntryNotification _entryNotification = Substitute.For<IEntryNotification>();

		[SetUp]
		public void Setup()
		{
			_uut = new DoorControl(_door, _userValidation, _entryNotification);
			_userValidation.ValidateEntryRequest(0).Returns(false);
			_userValidation.ValidateEntryRequest(1).Returns(true);
		}

		[Test]
		public void OpenDoor_Test()
		{
			
			_uut.RequestEntry(1);
			_userValidation.Received().ValidateEntryRequest(1);
			_entryNotification.Received().NotifyEntryGranted();
		}
	}
}

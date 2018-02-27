using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl
{
	public class DoorControl
	{
		private enum DoorState
		{
			DoorClosed,
			DoorOpening,
			DoorClosing,
			DoorBreached
		}

		private DoorState _state;
		private IDoor _door;
		private IUserValidation _userValidation;
		private IEntryNotification _entryNotification;

		public DoorControl(IDoor door, IUserValidation userValidation, IEntryNotification entryNotification)
		{
			this._door = door;
			this._userValidation = userValidation;
			this._entryNotification = entryNotification;
			_state = DoorState.DoorClosed;
		}

		public void RequestEntry(int id)
		{
			switch (_state)
			{
				case DoorState.DoorClosed:
					bool idOk = _userValidation.ValidateEntryRequest(id);
					if (idOk)
					{
						_door.Open();
						_entryNotification.NotifyEntryGranted();
						_state = DoorState.DoorOpening;
					}
					else
					{
						_entryNotification.NotifyEntryDenied();
					}
					break;
				default:
					break;
			}
		}

		public void DoorOpened()
		{
			switch (_state)
			{
				case DoorState.DoorOpening:
					_door.Close();
					_state = DoorState.DoorClosing;
					break;
				case DoorState.DoorClosed:
					_door.Close();
					_entryNotification.SignalAlarm();
					_state = DoorState.DoorBreached;
					break;
				default:
					break;
			}
		}

		public void DoorClosed()
		{
			switch (_state)
			{
				case DoorState.DoorClosing:
					_state = DoorState.DoorClosed;
					break;
				default:
					break;
			}
		}

	}
}

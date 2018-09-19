using System;
using StatePattern.Interfaces;

namespace StatePattern.DriveStates
{
	public class AtPark : IDriveState
	{
		public IDriveState Braking()
		{
			throw new NotImplementedException();
		}

		public IDriveState ToGearRatio(int targetGearRatio)
		{
			throw new NotImplementedException();
		}

		public IDriveState ToNeutral()
		{
			throw new NotImplementedException();
		}

		public IDriveState ToPark() => this;

		public IDriveState ToReverse()
		{
			throw new NotImplementedException();
		}
	}
}

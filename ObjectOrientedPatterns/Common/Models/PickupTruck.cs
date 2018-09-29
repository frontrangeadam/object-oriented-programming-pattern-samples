using StatePattern.Interfaces;

namespace Common.Models
{
	public class PickupTruck
	{
		public int Engine { get; }
		public int Trim { get; }
		public int Transmission { get; }
		public int PackageType { get; }

		private IDriveState DriveState { get; set; }

		public PickupTruck(
			int engine,
			int trim,
			int transmission, 
			int packageType)
		{
			Engine = engine;
			Trim = trim;
			Transmission = transmission;
			PackageType = packageType;

			// Initialize drive state from constructor.
			DriveState = DriveState.ToPark();
		}

		public void Accelerate(int targetSpeed) => DriveState = DriveState.ToGearRatio(2);

		public void ApplyBrake() => DriveState = DriveState.Braking();

		public void Drive() => DriveState = DriveState.ToGearRatio(1);

		public void Neutral() => DriveState = DriveState.ToNeutral();

		public void Park() => DriveState = DriveState.ToPark();

		public void Reverse() => DriveState = DriveState.ToReverse();
	}
}

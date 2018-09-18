namespace Common.Models
{
	public class PickupTruck
	{
		public int Engine { get; }
		public int Trim { get; }
		public int Transmission { get; }
		public int PackageType { get; }

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
		}
	}
}

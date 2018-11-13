using BuilderPattern;
using Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectOrientedPatterns.Tests
{
	[TestClass]
	public class BuilderPatternDemo
	{
		[TestMethod]
		public void BuildPickupTruckWithSpecs_ReturnsValidObject()
		{
			const int offRoadPkg = (int)AvailablePackages.OffRoad;
			const int extendedCab = (int)Trim.ExtendedCab;
			const int manual = (int)TransmissionType.Manual;
			const int v6 = (int)EngineType.V6;

			var truck = TruckBuilder
				.LightDutyTruck
					.WithEngine(v6)
					.AndTransmission(manual)
					.AndTrimOption(extendedCab)
					.AndPackage(offRoadPkg)
					.Build();

			Assert.AreEqual(truck.Engine, v6);
			Assert.AreEqual(truck.Transmission, manual);
			Assert.AreEqual(truck.Trim, extendedCab);
			Assert.AreEqual(truck.PackageType, offRoadPkg);
		}
	}
}

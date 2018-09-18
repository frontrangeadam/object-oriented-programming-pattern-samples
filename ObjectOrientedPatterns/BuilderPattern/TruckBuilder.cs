using BuilderPattern.Interfaces;
using Common.Models;

namespace BuilderPattern
{
	public class TruckBuilder :
		IEngineBuildStep,
		ITransmissionBuildStep,
		IPackageOptionBuildStep,
		ITrimOptionBuildStep,
		IPickupTruckBuilder
	{
		private int EngineType { get; set; }
		private int PackageType { get; set; }
		private int TransmissionType { get; set; }
		private int TrimType { get; set; }

		/// <summary>
		/// Prevent access to the parameterless constructor, so the caller can be guided through the process of creating a valid object.
		/// Use static <see cref="LightDutyTruck"/> method instead to start object creation.
		/// </summary>
		private TruckBuilder()
		{
		}

		/// <summary>
		/// Public entry point for caller.
		/// </summary>
		public static IEngineBuildStep LightDutyTruck => new TruckBuilder();

		public ITransmissionBuildStep WithEngine(int engineType)
		{
			return new TruckBuilder
			{
				EngineType = engineType
			};
		}

		public ITrimOptionBuildStep AndTransmission(int transmissionType)
		{
			return new TruckBuilder
			{
				EngineType = EngineType,
				TransmissionType = transmissionType
			};
		}
		public IPackageOptionBuildStep AndTrimOption(int trimOption)
		{
			return new TruckBuilder
			{
				EngineType = EngineType,
				TransmissionType = TransmissionType,
				TrimType = trimOption
			};
		}

		public IPickupTruckBuilder AndPackage(int pkgType)
		{
			return new TruckBuilder
			{
				EngineType = EngineType,
				TransmissionType = TransmissionType,
				TrimType = TrimType,
				PackageType = pkgType
			};
		}

		public PickupTruck Build()
		{
			return new PickupTruck(EngineType, TrimType, TransmissionType, PackageType);
		}
	}
}

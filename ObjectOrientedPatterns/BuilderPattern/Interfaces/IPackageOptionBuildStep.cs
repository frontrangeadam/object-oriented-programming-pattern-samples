namespace BuilderPattern.Interfaces
{
	public interface IPackageOptionBuildStep
	{
		IPickupTruckBuilder AndPackage(int pkgType);
	}
}
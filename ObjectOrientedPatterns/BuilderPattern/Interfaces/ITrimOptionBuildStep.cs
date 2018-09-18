namespace BuilderPattern.Interfaces
{
	public interface ITrimOptionBuildStep
	{
		IPackageOptionBuildStep AndTrimOption(int trimOption);
	}
}
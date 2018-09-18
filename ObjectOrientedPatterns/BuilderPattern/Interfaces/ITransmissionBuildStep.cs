namespace BuilderPattern.Interfaces
{
	public interface ITransmissionBuildStep
	{
		ITrimOptionBuildStep AndTransmission(int transmissionType);
	}
}
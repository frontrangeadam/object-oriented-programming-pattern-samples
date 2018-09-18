using BuilderPattern.Interfaces;

namespace BuilderPattern
{
	public interface IEngineBuildStep
	{
		ITransmissionBuildStep WithEngine(int engineType);
	}
}
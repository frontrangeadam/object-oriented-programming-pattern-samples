namespace StatePattern.Interfaces
{
	public interface IDriveState
	{
		IDriveState Braking();
		IDriveState ToGearRatio(int targetGearRatio);
		IDriveState ToNeutral();
		IDriveState ToPark();
		IDriveState ToReverse();
	}
}
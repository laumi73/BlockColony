public interface IState
{
	public void EnterState();

	public void ExitState();

	public void UpdateFrame();

	public void UpdatePhysics();
}

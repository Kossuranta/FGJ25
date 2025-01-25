using Godot;

public partial class RotateTowardsMovementDir : Node3D
{
	[Export]
	private CharacterBody3D m_characterBody;

	public override void _Process(double _delta)
	{
		float delta = (float) _delta;
		Vector3 velocity = m_characterBody.Velocity;
		if (velocity.Length() != 0)
		{
			Vector3 dir = m_characterBody.GlobalPosition + velocity;
			LookAt(dir);
		}
	}
}

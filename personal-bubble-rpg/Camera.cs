using Godot;

public partial class Camera : Camera3D
{
	[Export]
	private Vector3 m_offset = new(0, 5, 0.2f);

	public override void _Ready()
	{
		
	}

	public override void _Process(double _delta)
	{
		Player player = Player.Instance;
		if (player == null) return;
		Vector3 playerPos = Player.Instance.GlobalPosition;
		GlobalPosition = playerPos + m_offset;
	}
}

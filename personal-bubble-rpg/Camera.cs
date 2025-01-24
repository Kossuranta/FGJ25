using Godot;

public partial class Camera : Camera3D
{
	public override void _Ready()
	{
		
	}

	public override void _Process(double _delta)
	{
		Vector3 playerPos = GameManager.Player.GlobalPosition;
		Vector3 offset = new(0, 5, 0.2f);
		GlobalPosition = playerPos + offset;
	}
}

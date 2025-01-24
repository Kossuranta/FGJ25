using Godot;
using System;

public partial class Player : Node3D
{
	[Export]
	private float m_moveSpeed = 5f;

	[Export]
	private float m_rotateSpeed = 5f;

	public override void _Ready()
	{
		
	}

	public override void _Process(double _delta)
	{
		float delta = (float) _delta;
		Vector3 moveDir = new();
		float rotation = 0;

		// Check for input and set direction accordingly
		if (Input.IsActionPressed("move_forward"))
			moveDir.Z -= 1;

		if (Input.IsActionPressed("move_back"))
			moveDir.Z += 1;

		if (Input.IsActionPressed("turn_left"))
			rotation = 1;

		if (Input.IsActionPressed("turn_right"))
			rotation = -1;
		
		/*if (moveDir.Length() > 0)
		{
			moveDir = moveDir.Normalized();
		}*/

		Translate(moveDir * m_moveSpeed *  delta);
		RotateY(rotation * m_rotateSpeed * delta);
	}
}

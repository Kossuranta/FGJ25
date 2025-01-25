using Godot;
using System;

public partial class Player : Node3D
{
	public static Player Instance { get; private set; }
	[Export]
	private float m_moveSpeed = 5f;

	[Export]
	private float m_rotateSpeed = 5f;

	[Export]
	private int m_maxHealth = 3;

	public HealthSystem m_healthSystem;

	public override void _Ready()
	{
		Instance = this;
		m_healthSystem = new HealthSystem(m_maxHealth);
		GD.Print("Player ready");
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

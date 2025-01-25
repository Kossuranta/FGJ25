using Godot;

public partial class Player : CharacterBody3D
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
		/*float delta = (float) _delta;
		float rotation = 0;

		if (Input.IsActionPressed("turn_left"))
			rotation = 1;

		if (Input.IsActionPressed("turn_right"))
			rotation = -1;

		RotateY(rotation * m_rotateSpeed * delta);*/
	}
	
	public override void _PhysicsProcess(double _delta)
	{
		float delta = (float) _delta;
		Movement(delta);
	}

	private void Movement(float _delta)
	{
		Vector2 inputDir = Input.GetVector("turn_left", "turn_right", "move_forward", "move_back");
		Vector3 moveDir = new(inputDir.X, 0, inputDir.Y);
		Velocity = moveDir * m_moveSpeed;
		MoveAndCollide(Velocity * _delta);
		MoveAndSlide();
	}
}

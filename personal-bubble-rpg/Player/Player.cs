using Godot;

public partial class Player : Character
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

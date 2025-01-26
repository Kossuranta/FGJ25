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

	[Export]
	private AudioStreamPlayer m_footSteps;

	public HealthSystem m_healthSystem;
	public ItemType CurrentItem { get; set; }

	public override void _Ready()
	{
		Instance = this;
		m_healthSystem = new HealthSystem(m_maxHealth);
		m_healthSystem.OnHealthChanged += OnHealthChanged;
		GD.Print("Player ready");
	}

	private void OnHealthChanged(int _health)
	{
		if (_health <= 0)
			GameManager.Instance.GameOver();
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
		if (!GameManager.Instance.GameRunning)
		{
			Velocity = Vector3.Zero;
			if (m_footSteps.Playing)
				m_footSteps.Stop();
			return;
		}
		
		Vector2 inputDir = Input.GetVector("turn_left", "turn_right", "move_forward", "move_back");
		Vector3 moveDir = new(inputDir.X, 0, inputDir.Y);
		Velocity = moveDir * m_moveSpeed;
		MoveAndCollide(Velocity * _delta);
		MoveAndSlide();
		
		if (Velocity.Length() > 0)
		{
			if (!m_footSteps.Playing)
				m_footSteps.Play();
		}
		else
		{
			if (m_footSteps.Playing)
				m_footSteps.Stop();
		}
	}
}

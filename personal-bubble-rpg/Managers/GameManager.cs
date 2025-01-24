using Godot;

public partial class GameManager : Node
{
	[Export]
	private PackedScene m_mainLevelPrefab;
	
	[Export]
	private PackedScene m_playerPrefab;
	
	[Export]
	private PackedScene m_cameraPrefab;

	public Node3D m_mainLevel;
	public Node3D m_player;
	public Camera3D m_camera;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		InitLevel();
		InitPlayer();
		InitCamera();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double _delta)
	{
		Vector3 playerPos = m_player.GlobalPosition;
		Vector3 offset = new(0, 5, 0.2f);
		m_camera.GlobalPosition = playerPos + offset;
	}
	
	public void InitLevel()
	{
		if (m_mainLevelPrefab != null)
		{
			m_mainLevel = (Node3D)m_mainLevelPrefab.Instantiate();
			m_mainLevel.Position = new Vector3(0, 0, 0);
			AddChild(m_mainLevel);
		}
		else
		{
			GD.PrintErr("MainLevel is not assigned in the Inspector");
		}
	}
	
	public void InitPlayer()
	{
		if (m_playerPrefab != null)
		{
			m_player = (Node3D)m_playerPrefab.Instantiate();
			m_player.Position = new Vector3(5, 0, 5);
			AddChild(m_player);
		}
		else
		{
			GD.PrintErr("Player is not assigned in the Inspector");
		}
	}

	public void InitCamera()
	{
		if (m_cameraPrefab != null)
		{
			m_camera = (Camera3D)m_cameraPrefab.Instantiate();
			AddChild(m_camera);
		}
		else
		{
			GD.PrintErr("Camera is not assigned in the Inspector");
		}
	}
}

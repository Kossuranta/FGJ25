using Godot;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; }
	
	[Export]
	private PackedScene m_mainLevelPrefab;
	
	[Export]
	private PackedScene m_cameraPrefab;

	public static Node3D MainLevel { get; private set; }
	public static Camera3D Camera { get; private set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		
		InitLevel();
		InitCamera();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double _delta)
	{
		
	}
	
	public void InitLevel()
	{
		if (m_mainLevelPrefab != null)
		{
			MainLevel = (Node3D)m_mainLevelPrefab.Instantiate();
			MainLevel.Position = new Vector3(0, 0, 0);
			AddChild(MainLevel);
		}
		else
		{
			GD.PrintErr("MainLevel is not assigned in the Inspector");
		}
	}

	public void InitCamera()
	{
		if (m_cameraPrefab != null)
		{
			Camera = (Camera3D)m_cameraPrefab.Instantiate();
			AddChild(Camera);
		}
		else
		{
			GD.PrintErr("Camera is not assigned in the Inspector");
		}
	}
}

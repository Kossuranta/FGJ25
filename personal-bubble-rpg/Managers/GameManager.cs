using Godot;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; }
	
	[Export]
	private PackedScene m_mainLevelPrefab;
	
	[Export]
	private PackedScene m_cameraPrefab;

	[Export]
	private PackedScene m_hudPrefab;

	[Export]
	private PackedScene m_fightScenePrefab;

	public static Node3D MainLevel { get; private set; }
	public static Camera3D Camera { get; private set; }

	private Hud m_hud;
	private MarginContainer m_fightScene;
	
	public int RunCounter { get; private set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		StartGame();
	}

	public void GameOver()
	{
		StartGame();
	}

	public void StartGame()
	{
		RunCounter++;
		MainLevel?.QueueFree();
		m_hud?.QueueFree();
		Camera?.QueueFree();
		m_fightScene?.QueueFree();
		
		InitLevel();
		InitHud();
		InitCamera();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double _delta)
	{
		
	}

	public void StartFight(CharacterType _enemy)
	{
		m_fightScene = (MarginContainer) m_fightScenePrefab.Instantiate();
		AddChild(m_fightScene);
	}
	
	private void InitLevel()
	{
		MainLevel = (Node3D)m_mainLevelPrefab.Instantiate();
		MainLevel.Position = new Vector3(0, 0, 0);
		AddChild(MainLevel);
	}

	private void InitHud()
	{
		m_hud = (Hud)m_hudPrefab.Instantiate();
		AddChild(m_hud);
	}

	private void InitCamera()
	{
		Camera = (Camera3D)m_cameraPrefab.Instantiate();
		AddChild(Camera);
	}
}

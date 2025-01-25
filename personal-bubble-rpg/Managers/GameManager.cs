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

	[Export]
	private PackedScene m_gameOverPrefab;
	
	[Export]
	private PackedScene m_gameWinPrefab;

	public static Node3D MainLevel { get; private set; }
	public static Camera3D Camera { get; private set; }

	private Hud m_hud;
	private FightEncounter m_fightScene;
	private GameOver m_gameOver;
	private GameOver m_gameWin;
	
	public int RunCounter { get; private set; }

	private bool m_gameRunning;
	public bool GameRunning => m_gameRunning && m_fightScene == null && !GameWinState;
	public bool GameWinState { get; private set; }

	public override void _Ready()
	{
		Instance = this;
		StartGame(true);
	}

	public void GameOver()
	{
		m_fightScene?.QueueFree();
		m_fightScene = null;
		m_gameRunning = false;
		m_gameOver.Toggle(true, RunCounter);
	}

	public void GameWin()
	{
		GameWinState = true;
		m_fightScene?.QueueFree();
		m_fightScene = null;
		m_gameRunning = false;
		m_gameOver.Toggle(true, RunCounter);
	}

	public void RestartGame()
	{
		StartGame(false);
	}
	
	private void StartGame(bool _instant)
	{
		GD.Print("StartGame");
		RunCounter++;
		MainLevel?.QueueFree();
		m_hud?.QueueFree();
		Camera?.QueueFree();
		m_gameOver?.QueueFree();
		
		InitLevel();
		InitHud();
		InitCamera();
		InitGameOver();

		if (_instant)
		{
			FadeOutCompleted();
		}
		else
		{
			m_gameOver.Toggle(false, RunCounter);
			m_gameOver.FadeOutCompleted += FadeOutCompleted;
		}
	}

	private void FadeOutCompleted()
	{
		GD.Print("Continue");
		m_gameRunning = true;
	}

	public void StartFight(CharacterType _enemy)
	{
		m_fightScene = (FightEncounter) m_fightScenePrefab.Instantiate();
		AddChild(m_fightScene);
		m_fightScene.FightStart(_enemy);
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

	private void InitGameOver()
	{
		m_gameOver = (GameOver)m_gameOverPrefab.Instantiate();
		AddChild(m_gameOver);
	}
}

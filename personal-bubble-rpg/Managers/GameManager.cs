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

	[Export]
	private PackedScene m_playerSeenPrefab;

	[Export]
	private PackedScene m_cloudAnimPrefab;

	public static Node3D MainLevel { get; private set; }
	public static Camera3D Camera { get; private set; }

	private Hud m_hud;
	private FightEncounter m_fightScene;
	private GameOver m_gameOver;
	private GameOver m_gameWin;
	private CloudAnimScene m_cloudAnimScene;
	
	public int RunCounter { get; private set; }

	private bool m_gameRunning;
	public bool GameRunning => m_gameRunning && !GameWinState && !InFightScene;
	public bool GameWinState { get; private set; }
	public bool InFightScene { get; private set; }

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
		InFightScene = false;
		GD.Print("StartGame");
		RunCounter++;
		MainLevel?.QueueFree();
		m_hud?.QueueFree();
		Camera?.QueueFree();
		
		InitLevel();
		InitHud();
		InitCamera();
		InitGameOver();
		InitFightScene();

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
		m_cloudAnimScene.Visible = true;
		m_cloudAnimScene.FadeIn();
		m_cloudAnimScene.FadeInCompleted += CloudFadeInCompleted;
		
		InFightScene = true;
		m_fightScene.SetEnemy(_enemy);
	}

	private void CloudFadeInCompleted()
	{
		m_fightScene.Visible = true;
		m_fightScene.FightStart();
		m_cloudAnimScene.FadeOut();
		m_cloudAnimScene.FadeOutCompleted += CloudFadeOutCompleted;
	}

	private void CloudFadeOutCompleted()
	{
		m_cloudAnimScene.Visible = false;
	}

	public void EndFight(CharacterType _enemy)
	{
		InFightScene = false;
		m_fightScene.Visible = false;
		
		// Spawn reward
	}

	private void InitFightScene()
	{
		m_fightScene = (FightEncounter) m_fightScenePrefab.Instantiate();
		AddChild(m_fightScene);
		m_fightScene.Visible = false;

		if (m_cloudAnimScene == null)
		{
			m_cloudAnimScene = (CloudAnimScene) m_cloudAnimPrefab.Instantiate();
			AddChild(m_cloudAnimScene);
		}
		m_cloudAnimScene.Visible = false;
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
		if (m_gameOver != null)
			return;
		
		m_gameOver = (GameOver)m_gameOverPrefab.Instantiate();
		AddChild(m_gameOver);
	}
}

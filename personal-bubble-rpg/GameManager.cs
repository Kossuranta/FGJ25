using Godot;
using System;

public partial class GameManager : Node
{
	[Export]
	public PackedScene MainLevel;
	
	[Export]
	public PackedScene Player;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void InitLevel()
	{
		if (MainLevel != null)
		{
			Node3D mainLevel = (Node3D)MainLevel.Instantiate();
			mainLevel.Position = new Vector3(0, 0, 0);
			AddChild(mainLevel);
		}
		else
		{
			GD.PrintErr("MainLevel is not assigned in the Inspector");
		}
	}
	
	public void InitPlayer()
	{
		if (Player != null)
		{
			Node3D playerInstance = (Node3D)Player.Instantiate();
			playerInstance.Position = new Vector3(5, 0, 5);
			AddChild(playerInstance);
		}
		else
		{
			GD.PrintErr("Player is not assigned in the Inspector");
		}
	}
}

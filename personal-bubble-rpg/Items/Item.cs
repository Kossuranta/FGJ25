using Godot;
using System;

public partial class Item : Area3D
{
	[Export]
	public ItemType m_type;
	
	public override void _Ready()
	{
		// Connect the body_entered signal to the OnBodyEntered function
		Connect("body_entered", new Callable(this, "OnBodyEntered"));
	}

	private void OnBodyEntered(Node _body)
	{
		if (_body is CharacterBody3D)
		{
			// Player entered the collider, remove this object
			QueueFree();
		}
	}
}

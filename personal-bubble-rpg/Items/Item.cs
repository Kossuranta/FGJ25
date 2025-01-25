using Godot;
using System;

public partial class Item : Area3D
{
	[Export]
	public ItemType m_type;

	[Export]
	private bool m_autoPickup;
	
	public override void _Ready()
	{
		// Connect the body_entered signal to the OnBodyEntered function
		Connect("body_entered", new Callable(this, "OnBodyEntered"));
	}

	private void OnBodyEntered(Node _body)
	{
		if (_body is Player player)
		{
			if (m_autoPickup)
				QueueFree();
		}
	}
}

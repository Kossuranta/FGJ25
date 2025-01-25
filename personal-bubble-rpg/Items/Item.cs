using Godot;
using System;

public partial class Item : Area3D
{
	[Export]
	public ItemType m_type;

	[Export]
	private bool m_autoPickup;

	private void OnTriggerEnter(Node _body)
	{
		if (_body is Player player)
		{
			GD.Print($"OnTriggerEnter {m_type}");
			if (m_autoPickup)
				QueueFree();
			else
				Hud.Instance.ShowPickup(this);
		}
	}
	
	private void OnTriggerExit(Node _node)
	{
		if (_node is not Player player)
			return;
		
		GD.Print($"OnTriggerExit {m_type}");
		Hud.Instance.HidePickup();
	}
}

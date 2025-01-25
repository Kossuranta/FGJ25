using Godot;
using System;

public partial class OnTriggerEnter : Node
{
	public Action m_onTriggerEnter;
	
	public override void _Ready()
	{
		// Connect the body_entered signal to the OnBodyEntered function
		Connect("body_entered", new Callable(this, "OnBodyEntered"));
	}

	private void OnBodyEntered(Node _body)
	{
		if (_body is Player)
		{
			m_onTriggerEnter?.Invoke();
		}
	}
}

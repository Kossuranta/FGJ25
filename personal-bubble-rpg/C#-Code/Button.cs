using Godot;
using System;
using System.Diagnostics.CodeAnalysis;

public partial class Button : Godot.Button
{

	public void OnPressed()
	{
		GD.Print("Button pressed");
		Player.Instance.m_healthSystem.ApplyDamage(1);
	}
}

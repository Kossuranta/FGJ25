using Godot;
using System;
using System.Diagnostics.CodeAnalysis;

public partial class HSlider : Godot.HSlider
{

	public void Health_Down(float _currentHealth)
	{
		Value = _currentHealth;
		GD.Print("Value changed: " + _currentHealth);
	}

	public override void _Ready()
	{
		Player.Instance.m_healthSystem.OnHealthChanged += Health_Down;
	}

}

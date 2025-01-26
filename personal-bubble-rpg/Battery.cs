using Godot;
using System;

public partial class Battery : MarginContainer
{
    [Export]
    private Sprite2D m_fill;

    public override void _Ready()
    {
        Player.Instance.m_healthSystem.OnHealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int _health)
    {
        float percentage = (float) _health / Player.Instance.m_healthSystem.MaxHealth;
        float scale = 0.3f * percentage;
        m_fill.Scale = new Vector2(0.3f, scale);
    }
}

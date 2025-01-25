using Godot;

public partial class HealthSlider : VSlider
{
	public override void _Ready()
	{
		MaxValue = Player.Instance.m_healthSystem.MaxHealth;
		Value = Player.Instance.m_healthSystem.Health;
		Player.Instance.m_healthSystem.OnHealthChanged += Health_Down;
	}

	public void Health_Down(int _currentHealth)
	{
		Value = _currentHealth;
		GD.Print("Value changed: " + _currentHealth);
	}
}

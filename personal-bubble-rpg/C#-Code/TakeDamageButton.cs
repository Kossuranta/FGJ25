using Godot;

public partial class TakeDamageButton : Button
{

	public void OnPressed()
	{
		GD.Print("Button pressed");
		Player.Instance.m_healthSystem.ApplyDamage(1);
	}
}

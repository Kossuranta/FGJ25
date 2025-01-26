using System;
using Godot;

public class HealthSystem
{
	public int Health { get; private set; }
    public int MaxHealth { get; }
    
    public Action<int> OnHealthChanged;

    public HealthSystem(int _maxHealth)
    {
        Health = _maxHealth;
        MaxHealth = _maxHealth;
    }

    public void ApplyDamage(int _damage)
	{
        
		Health -= _damage;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
		GD.Print(Health);
        OnHealthChanged?.Invoke(Health);
	}
}

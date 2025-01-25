

using System;

public partial class HealthSystem
{
    
	private int health;
    private int maxHealth;
    public Action<float> OnHealthChanged;

	public int Health
	{
		get { return health; }
		private set { health = value; }
	}

    public HealthSystem(int _maxHealth)
    {
        health = _maxHealth;
        maxHealth = _maxHealth;
    }


	public void ApplyDamage(int _damage)
	{
		health -= _damage;
        OnHealthChanged?.Invoke(health / maxHealth);
		
	}
}

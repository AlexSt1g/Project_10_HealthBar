using System;
using UnityEngine;

public class DamageablePerson : MonoBehaviour
{
    public event Action<int, int> HealthChanged;

    [field: SerializeField] public int MaxHealth { get; protected set; } = 100;
    public int Health { get; protected set; }

    private void Awake()
    {
        Health = MaxHealth;
    }

    public virtual void TakeHit(int damageValue)
    {
        if (damageValue < 0)
            throw new InvalidOperationException(nameof(damageValue));
        else if (damageValue > Health)
            Health = 0;
        else
            Health -= damageValue;

        HealthChanged?.Invoke(Health, MaxHealth);
    }

    public virtual void Heal(int healingValue)
    {
        if (healingValue < 0)
            throw new InvalidOperationException(nameof(healingValue));
        else
            Health += healingValue;

        if (Health > MaxHealth)
            Health = MaxHealth;

        HealthChanged?.Invoke(Health, MaxHealth);
    }
}

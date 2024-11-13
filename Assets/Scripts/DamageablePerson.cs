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
        damageValue = Mathf.Clamp(damageValue, 0, Health);
        Health -= damageValue;

        HealthChanged?.Invoke(Health, MaxHealth);
    }

    public virtual void Heal(int healingValue)
    {
        healingValue = Mathf.Clamp(healingValue, 0, MaxHealth - Health);
        Health += healingValue;

        HealthChanged?.Invoke(Health, MaxHealth);
    }
}

using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private DamageablePerson _person;
    [SerializeField] private HealthBar _healthBar;    

    private void Start()
    {
        DisplayHealth(_person.Health, _person.MaxHealth);
    }

    private void OnEnable()
    {
        _person.HealthChanged += DisplayHealth;
    }

    private void OnDisable()
    {
        _person.HealthChanged += DisplayHealth;
    }

    private void DisplayHealth(int currentHealth, int maxHealth)
    {
        _healthBar.DisplayHealth(currentHealth, maxHealth);        
    }
}

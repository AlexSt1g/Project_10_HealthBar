using UnityEngine;

[RequireComponent(typeof(HealthView))]
public abstract class HealthBar : MonoBehaviour
{
    private HealthView _healthView;

    private void Awake()
    {
        _healthView = GetComponent<HealthView>();
    }

    private void OnEnable()
    {
        _healthView.DisplayedHealthChanged += DisplayHealth;
    }

    private void OnDisable()
    {
        _healthView.DisplayedHealthChanged -= DisplayHealth;
    }

    protected virtual void DisplayHealth(int currentHealth, int maxHealth)
    {
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        else if (currentHealth < 0)
            currentHealth = 0;        
    }

    protected float GetHealthValueForSlider(int currentHealth, int maxHealth)
    {
        return (float)currentHealth / maxHealth;
    }
}

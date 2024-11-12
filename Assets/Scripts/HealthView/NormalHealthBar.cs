using UnityEngine;
using UnityEngine.UI;

public class NormalHealthBar : HealthBar
{
    [SerializeField] private Slider _healthBarSlider;
    
    protected override void DisplayHealth(int currentHealth, int maxHealth)
    {
        base.DisplayHealth(currentHealth, maxHealth);

        _healthBarSlider.value = GetHealthValueForSlider(currentHealth, maxHealth);
    }
}

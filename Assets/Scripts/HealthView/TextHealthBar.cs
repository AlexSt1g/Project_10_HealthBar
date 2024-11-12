using TMPro;
using UnityEngine;

public class TextHealthBar : HealthBar
{
    [SerializeField] private TextMeshProUGUI _healthText;    

    protected override void DisplayHealth(int currentHealth, int maxHealth)
    {
        base.DisplayHealth(currentHealth, maxHealth);
        
        _healthText.text = $"Health: {currentHealth}/{maxHealth}";
    }
}

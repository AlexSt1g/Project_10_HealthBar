using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthBar
{
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private float _sliderHealthValueChangeSpeed = 0.5f;
    
    private Coroutine _coroutine;

    protected override void DisplayHealth(int currentHealth, int maxHealth)
    {
        base.DisplayHealth(currentHealth, maxHealth);

        if (_coroutine != null)        
            StopCoroutine(_coroutine);
        
        _coroutine = StartCoroutine(SlowChangeSliderValue(currentHealth, maxHealth));
    }

    private IEnumerator SlowChangeSliderValue(int currentHealth, int maxHealth)
    {
        float targetSliderHealthValue = GetHealthValueForSlider(currentHealth, maxHealth);
        float currentSliderHealthValue = _healthBarSlider.value;
        float delay = 1f;  

        for (float i = 0; i < delay; i += _sliderHealthValueChangeSpeed * Time.deltaTime)
        {
            yield return null;

            _healthBarSlider.value = Mathf.MoveTowards(currentSliderHealthValue, targetSliderHealthValue, i);
        }

        _healthBarSlider.value = targetSliderHealthValue;
    }
}

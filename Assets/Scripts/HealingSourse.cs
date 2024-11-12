using UnityEngine;
using UnityEngine.UI;

public class HealingSourse : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _healingValue;
    [SerializeField] private DamageablePerson _target;

    private void OnEnable()
    {
        _button.onClick.AddListener(HandleButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        _target.Heal(_healingValue);
    }
}

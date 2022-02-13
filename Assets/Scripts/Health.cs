using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private UnityEvent<float> _changedValue = new UnityEvent<float>();

    public event UnityAction<float> ChangedValue
    {
        add => _changedValue.AddListener(value);
        remove => _changedValue.RemoveListener(value);
    }

    public bool IsAlive => _currentValue > MinValue;
    public const float MaxValue = 100;

    private float _currentValue;
    private const float MinValue = 0;
    private const float Delta = 10;

    private void Start()
    {
        _currentValue = MaxValue;
    }

    public void TakeDamage()
    {
        _currentValue = Mathf.Clamp(_currentValue - Delta, MinValue, MaxValue);

        _changedValue.Invoke(_currentValue);
    }

    public void Heal()
    {
        if (IsAlive)
            _currentValue = Mathf.Clamp(_currentValue + Delta, MinValue, MaxValue);

        _changedValue.Invoke(_currentValue);
    }
}

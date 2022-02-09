using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    private Slider _slider;
    private Health _health;
    private WaitForSeconds _waitingTime = new WaitForSeconds(0.01f);

    private const float HealthFadeRate = 1;

    private void Start()
    {
        _health = GetComponentInParent<Health>();
        _slider = GetComponent<Slider>();

        _slider.value = _health.CurrentValue;
    }

    private IEnumerator SmoothChange()
    {
        float targetValue = _health.CurrentValue;

        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, HealthFadeRate);
            yield return _waitingTime;
        }
    }

    public void ShowCurrentHealth()
    {
        StartCoroutine(SmoothChange());
    }
}

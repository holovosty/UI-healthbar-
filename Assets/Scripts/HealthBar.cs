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

        _slider.value = Health.MaxValue;
        
        _health.ChangedValue += SetCurrentHealth;
    }

    private void OnDisable()
    {
        _health.ChangedValue -= SetCurrentHealth;
    }

    private IEnumerator SmoothChange(float currentHealth)
    {
        while (_slider.value != currentHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, currentHealth, HealthFadeRate);
            yield return _waitingTime;
        }
    }

    public void SetCurrentHealth(float currentHealth)
    {
        StartCoroutine(SmoothChange(currentHealth));
    }
}

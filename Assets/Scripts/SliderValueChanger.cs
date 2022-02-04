using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SliderValueChanger : MonoBehaviour
{
    private Slider _slider;
    private Health _health;
    private WaitForSeconds _waitingTime = new WaitForSeconds(0.01f);
    private const float _healthFadeRate = 1;

    private void Start()
    {
        _health = GetComponentInParent<Health>();
        _slider = GetComponent<Slider>();

        _slider.value = Health.MaxValue;
    }

    private IEnumerator SmoothChange()
    {
        float targetValue = _health.CurrentValue;

        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _healthFadeRate);
            yield return _waitingTime;
        }
    }

    public void ChangeValue()
    {
        StartCoroutine(SmoothChange());
    }


}

using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrentValue { get; private set; }
    public bool IsAlive { get; private set; }

    private const float MinValue = 0, MaxValue = 100, Delta = 10;

    private void Start()
    {
        CurrentValue = MaxValue;
    }

    public void TakeDamage()
    {
        CurrentValue = Mathf.Clamp(CurrentValue - Delta, MinValue, MaxValue);

        IsAlive = CurrentValue > MinValue;
    }

    public void Heal()
    {
        if (IsAlive)
            CurrentValue = Mathf.Clamp(CurrentValue + Delta, MinValue, MaxValue);
    }
}

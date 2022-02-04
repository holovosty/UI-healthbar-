using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrentValue;

    public const float MinValue = 0, MaxValue = 100, Delta = 10;

    private void Start()
    {
        CurrentValue = MaxValue;
    }

    public void TakeDamage()
    {
        if (CurrentValue >= Delta && CurrentValue > MinValue)
            CurrentValue -= Delta;
        else if (CurrentValue < Delta && CurrentValue > MinValue)
            CurrentValue = MinValue;
    }

    public void Heal()
    {
        if (CurrentValue <= (MaxValue - Delta) && CurrentValue > MinValue)
            CurrentValue += Delta;
        else if (CurrentValue >= (MaxValue - Delta) && CurrentValue < MaxValue && CurrentValue > MinValue)
            CurrentValue = MaxValue;
    }
}

using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]

public class PlayerAnimator : MonoBehaviour
{
    private Animator _player;
    private Health _health;

    private const string _heal = "Heal";
    private const string _takeDamage = "TakeDamage";
    private const string _death = "Death";


    private void Start()
    {
        _player = GetComponent<Animator>();
        _health = GetComponent<Health>();
    }

    public void Heal()
    {
        if (_health.CurrentValue > Health.MinValue && _health.CurrentValue <= Health.MaxValue)
            _player.SetTrigger(_heal);
    }

    public void TakeDamage()
    {
        if (_health.CurrentValue >= Health.Delta)
            _player.SetTrigger(_takeDamage);
        else if (_health.CurrentValue < Health.Delta)
            _player.SetTrigger(_death);
    }
}

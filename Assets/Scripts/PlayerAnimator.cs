using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]

public class PlayerAnimator : MonoBehaviour
{
    private Animator _player;
    private Health _health;

    private const string HealTrigger = "Heal", TakeDamageTrigger = "TakeDamage", DeathTrigger = "Death";

    private void Start()
    {
        _player = GetComponent<Animator>();
        _health = GetComponent<Health>();
    }

    public void Heal()
    {
        if (_health.IsAlive)
            _player.SetTrigger(HealTrigger);
    }

    public void TakeDamage()
    {
        if (_health.IsAlive)
            _player.SetTrigger(TakeDamageTrigger);
        else if (!_health.IsAlive)
            _player.SetTrigger(DeathTrigger);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Health ability for unit
/// </summary>
public class Health : Ability
{
    public event System.Action onDied;

    public float maxHp = 100;
    [Range(0, 1)]
    [SerializeField]
    [UnityEngine.Serialization.FormerlySerializedAs("hp")]
    float _hp = 1;

    /// <summary>
    /// normalized hp
    /// </summary>
    public float hp => _hp;
    public bool isDead { get; private set; }

    public void Die()
    {
        if (isDead)
            return;
        _hp = 0;
        isDead = true;
        onDied?.Invoke();
    }

    public void ChangeHp(float newHp)
    {
        if (isDead)
            return;
        _hp = Mathf.Clamp01(newHp);
        if (newHp <= 0)
            Die();
    }
    public void TakeDamage(float amount)
    {
        if (isDead)
            return;
        var normalizedAmount = amount / maxHp;
        ChangeHp(hp - normalizedAmount);
    }
}

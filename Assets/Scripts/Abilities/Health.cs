using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Health ability for unit
/// </summary>
public class Health : Ability
{
    public event System.Action onDie;
    public event System.Action<float> onTakeDamage;

    public float maxHp = 100;
    [Range(0, 1)]
    [SerializeField]
    [UnityEngine.Serialization.FormerlySerializedAs("hp")]
    float _hp = 1;

    public GameObject deathPrefab;
    public bool dontDestroyOnDie;

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
        onDie?.Invoke();
        if (deathPrefab)
            Instantiate(deathPrefab, transform.position, transform.rotation);
        if (!dontDestroyOnDie)
            Destroy(unit.gameObject);
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
        onTakeDamage?.Invoke(amount);
        ChangeHp(hp - normalizedAmount);
    }
}

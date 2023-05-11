using UnityEngine;

/// <summary>
/// Abstract class to any ability that can cause damage to health
/// </summary>
public abstract class Damaging : Ability
{
    //fields
    public float damage = 10;

    //functions

    /// <summary>
    /// Applies damage a target health
    /// </summary>
    public virtual void ApplyDamage(Health target)
    {
        target.TakeDamage(damage);
    }
    /// <summary>
    /// should ignore target health
    /// </summary>
    public virtual bool IsIgnored(Health target)
    {
        return false;
    }
}
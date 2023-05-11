using UnityEngine;

public abstract class Weapon : Ability
{
    public virtual bool isAttacking { get; }
    public virtual bool CanAttack() => true;
    public virtual void Attack() { }
    /// <summary>
    /// interrupts the current attack
    /// </summary>
    public virtual void Halt() { }
    public virtual void SetDirection(Vector2 direction)
    {
        transform.right = direction;
    }
}
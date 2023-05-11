using System.Collections.Generic;
using System.Collections;
using UnityEngine;

/// <summary>
/// A base class for very generic weapon, that has main common propeties
/// </summary>
public abstract class GenericWeapon : Weapon
{
    //fields
    public float damage = 20;
    public float reload = 0.5f;
    /// <summary>
    /// A delay time between the actual attack
    /// </summary>
    public float delay = 0;
    public float range = 10;


    //variables
    Duration reloadDur = new Duration();
    Duration delayDur = new Duration();
    IEnumerator attackCoro; //current Attack Coro
    bool _isAttacking;

    //propeties
    public override bool isAttacking => _isAttacking;

    //functions
    public override bool CanAttack()
    {
        return base.CanAttack() && reloadDur.isTimeout && !isAttacking;
    }
    public override void Attack()
    {
        base.Attack();
        StartCoroutine(attackCoro = AttackCoro());
        // reloadDur.StartBy(reload);
    }
    public override void Halt()
    {
        if (attackCoro != null)
            StopCoroutine(attackCoro);
        attackCoro = null;
    }
    /// <summary>
    /// Does the attack action
    /// </summary>
    public abstract void ActualAttack();

    IEnumerator AttackCoro()
    {
        _isAttacking = true;
        delayDur.StartBy(delay);
        yield return new WaitForSeconds(delay);
        ActualAttack();
        reloadDur.StartBy(reload);
        attackCoro = null;
        _isAttacking = false;
    }
}
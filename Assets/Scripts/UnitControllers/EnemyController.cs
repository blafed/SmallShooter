using UnityEngine;

public class EnemyController : UnitController
{
    NpcFollow follow;
    Hero target => Hero.current;
    Weapon weapon;

    private void Awake()
    {
        follow = GetComponent<NpcFollow>();
        weapon = unit.GetComponentInChildren<Weapon>();
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        if (follow)
        {
            follow.target = target;
            if (weapon && follow.isReachTarget)
            {
                if (weapon.CanAttack())
                    weapon.Attack();
            }
        }
    }
}
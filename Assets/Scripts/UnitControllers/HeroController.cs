using UnityEngine;

/// <summary>
/// Controls the hero
/// </summary>
public class HeroController : UnitController
{
    public Hero hero => (Hero)unit;
    Movement movement => hero.movement;
    Weapon weapon => hero.weapon;

    private void FixedUpdate()
    {
        var inp = InputManager.instance;


        var isInverse = hero.SetDirection(inp.lookDirection);
        if (inp.lookDirection.sqrMagnitude > .001f)
        {
            weapon.SetDirection(isInverse ? -inp.lookDirection : inp.lookDirection);
        }


        movement.SetMovement(Vector2.ClampMagnitude(inp.movement, 1));
        if (inp.isAttack)
        {
            if (hero.weapon && hero.weapon.CanAttack())
                hero.weapon.Attack();
        }
    }
}
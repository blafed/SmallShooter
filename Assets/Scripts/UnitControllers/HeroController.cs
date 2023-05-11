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
        movement.inputMovement = Vector2.ClampMagnitude(inp.movement, 1);
        weapon.SetDirection(inp.lookDirection);
        if (inp.isAttack)
        {
            if (hero.weapon && hero.weapon.CanAttack())
                hero.weapon.Attack();
        }

    }
}
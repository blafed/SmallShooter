using UnityEngine;

/// <summary>
/// Controls the hero
/// </summary>
public class HeroController : UnitController
{
    public Hero hero => (Hero)unit;
    Movement movement => hero.movement;
    private void FixedUpdate()
    {
        var inp = InputManager.instance;
        movement.inputMovement = Vector2.ClampMagnitude(inp.movement, 1);
    }
}
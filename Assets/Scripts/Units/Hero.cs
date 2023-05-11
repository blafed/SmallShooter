using UnityEngine;

/// <summary>
/// Represents the main character that can be controlled by player
/// </summary>
[RequireComponent(typeof(Movement), typeof(Health), typeof(HeroController))]
public class Hero : Unit
{
    public Movement movement => this.GetCachedComponent(ref _movement);
    public HeroController controller => this.GetCachedComponent(ref _controller);
    public Weapon weapon => this.GetCachedComponentInChildren(ref _weapon);
    Movement _movement;
    HeroController _controller;
    Weapon _weapon;

}
using UnityEngine;

/// <summary>
/// Represents the main character that can be controlled by player
/// </summary>
[RequireComponent(typeof(Movement), typeof(Health), typeof(HeroController))]
public class Hero : Character
{
    public static Hero current;
    public HeroController controller => this.GetCachedComponent(ref _controller);
    public Weapon weapon => this.GetCachedComponentInChildren(ref _weapon);
    HeroController _controller;
    Weapon _weapon;


    private void Awake()
    {
        if (!current)
            current = this;
    }

}
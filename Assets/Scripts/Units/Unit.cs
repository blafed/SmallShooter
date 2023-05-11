using UnityEngine;

/// <summary>
/// Base class of all units. It represnts a game play object
/// </summary>
public class Unit : MonoBehaviour
{
    public Health health => this.GetCachedComponent(ref _health);
    Health _health;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Health ability for unit
/// </summary>
public class Health : Ability
{
    public float maxHp = 100;
    [Range(0, 1)]
    public float hp = 1;
}

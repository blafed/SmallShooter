using UnityEngine;

/// <summary>
/// Abstract class that is base of any unit controller
/// Controller controls the unit abilities by an input or behaviour tree
/// </summary>
public abstract class UnitController : MonoBehaviour
{
    public Unit unit => this.GetCachedComponent(ref _unit);
    Unit _unit;
}
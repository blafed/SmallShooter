using UnityEngine;

public abstract class NpcScript : MonoBehaviour
{
    public Unit unit => this.GetCachedComponentInParent(ref _unit);
    Unit _unit;
}
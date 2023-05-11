using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Damage ability that interacting with unit's collider/s
/// </summary>
public class DamagingInteract : Damaging
{

    //fields
    [Min(0)]
    public int maxInteractions = 1; //zero means infinity

    //variables
    Dictionary<Health, int> interactionTable = new Dictionary<Health, int>();

    //properties
    public int interactionCount { get; protected set; }
    public int successedInteractionCount { get; protected set; }

    //functions
    public virtual void Interact(Collider2D collider)
    {
        if (IsIgnored(collider))
            return;
        var unit = collider.GetComponentInParent<Unit>();
        interactionCount++;

        if (unit && unit.health)
        {
            var target = unit.health;
            if (!IsIgnored(target))
            {
                if (interactionTable.ContainsKey(target))
                    interactionTable[target]++;
                else
                    interactionTable.Add(target, 1);
                OnInteractionSuccess(target);
            }
        }
        if (maxInteractions > 0)
            if (interactionCount >= maxInteractions)
                Terminate();

    }

    protected virtual void OnInteractionSuccess(Health health)
    {
        ApplyDamage(health);
    }

    public virtual bool IsIgnored(Collider2D collider)
    {
        return false;
    }
    protected virtual void Terminate()
    {
        if (unit.health)
            unit.health.Die();
        else
            Destroy(unit.gameObject);
    }
}
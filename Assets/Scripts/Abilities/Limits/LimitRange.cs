using UnityEngine;

public class LimitRange : Ability
{
    public float maxRange = 10;

    Vector2 startPoint;

    private void Start()
    {
        startPoint = unit.position;
    }

    private void FixedUpdate()
    {
        if ((startPoint - unit.position).sqrMagnitude > maxRange.Squared())
            Destroy(unit.gameObject);
    }
}
using UnityEngine;

public class NpcFollow : NpcScript
{
    public enum Method
    {
        Normal,
        SameXAxis,
        SameYAxis,
    }
    public Method method;
    [Space]
    public Unit target;
    [Tooltip("The radius of the follow")]
    public float maxDistance = 5;
    public float stopDistance = .5f;
    [Tooltip("if enabled the unit will try to get far from the target if it within the stop distance")]
    public bool avoidStopDistance = true;

    //cache
    Movement _movement;

    public bool isFollowing { get; private set; }
    public bool isReachTarget { get; private set; }
    Movement movement => unit.GetCachedComponent(ref _movement);



    private void FixedUpdate()
    {
        if (target)
        {
            Vector2 dir;
            if (target.health && target.health.isDead)
            {
                dir = new Vector2();
                isFollowing = false;
                isReachTarget = false;
            }
            else
            {
                dir = GetMovementDirection(target);
                isFollowing = dir.sqrMagnitude > .01f;
                isReachTarget = !isFollowing;
                var lookDir = (target.position - unit.position).normalized;
                if (unit is Character character)
                {
                    character.SetDirection(lookDir);
                }
            }
            if (movement)
                movement.SetMovement(dir);
        }
        else
        {
            isReachTarget = false;
            isFollowing = false;
        }
    }


    public Vector2 GetMovementDirection(Unit target)
    {
        var diff = target.position - unit.position;

        var dst = diff.sqrMagnitude;
        Vector2 movementDir = new Vector2();


        if (dst < maxDistance.Squared())
        {
            movementDir = diff;
        }
        if (dst < stopDistance.Squared())
        {
            if (avoidStopDistance)
                movementDir = -diff;
            else
                movementDir = new Vector2();
        }

        if (method == Method.SameXAxis)
            movementDir.x = diff.x;
        else if (method == Method.SameYAxis)
            movementDir.y = diff.y;

        if (movementDir.sqrMagnitude < .01f)
            return Vector2.zero;
        else
            movementDir = movementDir.normalized;


        return movementDir;
    }
}
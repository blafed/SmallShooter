using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Movement), typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class Character : Unit
{
    public Movement movement => this.GetCachedComponent(ref _movement);
    public new CapsuleCollider2D collider => this.GetCachedComponent(ref _collider);
    public Rigidbody2D rb => this.GetCachedComponent(ref _rb);
    Rigidbody2D _rb;
    Movement _movement;
    CapsuleCollider2D _collider;
    private void Reset()
    {
        rb.freezeRotation = true;
        rb.gravityScale = 0;
    }

    /// <summary>
    /// Updates the direction of the character
    /// returns true if it at inversed direction
    /// </summary>
    public bool SetDirection(Vector2 lookDirection)
    {
        if (lookDirection.sqrMagnitude > .001f)
        {
            var scale = transform.localScale;
            var isInverse = lookDirection.x < 0;
            scale.x = isInverse ? -1 : 1;
            transform.localScale = scale;
            return isInverse;
        }
        return false;
    }
}
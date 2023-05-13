using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), (typeof(Movement)))]
public class Projectile : Unit
{
    public Weapon weapon { get; set; }
    public Movement movement => this.GetCachedComponent(ref _movement);
    public Rigidbody2D rb => this.GetCachedComponent(ref _rb);
    public Damaging damage => this.GetCachedComponentInChildren(ref _damage);

    //cache
    Rigidbody2D _rb;
    Movement _movement;
    Damaging _damage;
    LimitRange _limitRange;
    LimitLifeTime _limitLifeTime;


    private void Reset()
    {
        rb.gravityScale = 0;
    }
    private void OnValidate()
    {
        AssertComponentInChildren<Damaging>();
    }

    public void SetMaxRange(float maxRange)
    {
        _limitRange = gameObject.GetOrAddComponent<LimitRange>();
        _limitRange.maxRange = maxRange;
        _limitRange.enabled = maxRange > 0;
    }
    public void SetMaxLifeTime(float maxLifeTime)
    {
        _limitLifeTime = gameObject.GetOrAddComponent<LimitLifeTime>();
        _limitRange.maxRange = maxLifeTime;
        _limitRange.enabled = maxLifeTime > 0;
    }

}
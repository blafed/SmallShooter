using UnityEngine;

public class LimitLifeTime : Ability
{
    public float maxLifeTime = 5;

    float startAtTime;

    private void Start()
    {
        startAtTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (Time.time > startAtTime + maxLifeTime)
            Destroy(unit.gameObject);
    }
}
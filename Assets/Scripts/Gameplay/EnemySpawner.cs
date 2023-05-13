using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner current;
    public float frequency = .1f;
    public MinMax radius = new MinMax(5, 10);
    public float avoidanceRadius = 1f;
    public List<GameObject> prefabs = new List<GameObject>();


    Duration frequencyDur = new Duration();

    private void Awake()
    {
        current = this;
    }
    private void Start()
    {
        if (!current)
            current = this;
    }
    private void FixedUpdate()
    {
        if (frequencyDur.isTimeout)
        {
            frequencyDur.StartBy(frequency);
            for (int i = 0; i < 100; i++)
            {
                if (Spawn())
                    break;
            }
        }
    }

    public bool Spawn()
    {
        var point = (Vector2)transform.position + Random.insideUnitCircle.normalized * radius.random;
        if (Physics2D.CircleCast(point, avoidanceRadius, Vector2.up).collider)
            return false;

        var prefab = prefabs.GetRandom();
        var go = Instantiate(prefab, point, Quaternion.identity);
        return true;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius.min);
        Gizmos.DrawWireSphere(transform.position, radius.max);
    }
}
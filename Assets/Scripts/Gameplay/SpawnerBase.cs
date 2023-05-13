using UnityEngine;

public class SpawnerBase : MonoBehaviour
{
    public GameObject prefab;
    public virtual void Spawn(SpawningArea area)
    {

    }
}

public abstract class SpawningArea
{
    public abstract Vector2 GetPoint();
}
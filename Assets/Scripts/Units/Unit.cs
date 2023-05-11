using UnityEngine;

/// <summary>
/// Base class of all units. It represnts a game play object
/// </summary>
public class Unit : MonoBehaviour
{
    public Vector2 position
    {
        get => transform.position;
        set => transform.position = value;
    }
    public Health health => this.GetCachedComponent(ref _health);
    Health _health;

    protected void AssertComponentInChildren<T>()
    {
        T t = GetComponentInChildren<T>();

        if (t == null)
        {
            Debug.LogError($"{typeof(T).ToString()} is required!! by " + this, this);
        }
    }
}
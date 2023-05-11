using UnityEngine;

/// <summary>
/// Any component associated to unit
/// </summary>
public class Ability : MonoBehaviour
{
    /// <summary>
    /// The owner unit of this component
    /// </summary>
    public Unit unit { get; set; }

    protected virtual void Awake()
    {
        unit = GetComponentInParent<Unit>();
    }
}
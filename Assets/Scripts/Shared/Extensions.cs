using UnityEngine;
public static partial class Extensions
{
    public static float Squared(this float f) => f * f;

    public static T GetCachedComponent<T>(this Component obj, ref T cache)
    {
        if (cache != null)
            return cache;
        return cache = obj.GetComponent<T>();
    }
    public static T GetCachedComponentInParent<T>(this Component obj, ref T cache)
    {
        if (cache != null)
            return cache;
        return cache = obj.GetComponentInParent<T>();
    }
    public static T GetCachedComponentInChildren<T>(this Component obj, ref T cache)
    {
        if (cache != null)
            return cache;
        return cache = obj.GetComponentInChildren<T>();
    }
    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        var comp = go.GetComponent<T>();
        if (comp)
            return comp;
        return go.AddComponent<T>();
    }
    public static void SetLayerRecrusive(this GameObject go, int layer)
    {
        go.layer = layer;
        foreach (Transform t in go.transform)
        {
            SetLayerRecrusive(t.gameObject, layer);
        }
    }
}


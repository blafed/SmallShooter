using UnityEngine;
public static partial class Extensions
{
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
}
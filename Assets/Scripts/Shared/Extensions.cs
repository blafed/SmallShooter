using System.Collections.Generic;
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
    public static void ReActivate(this GameObject go)
    {
        go.SetActive(false);
        go.SetActive(true);
    }

    public static T GetRandom<T>(this IReadOnlyList<T> list)
    {
        if (list.Count == 0)
            return default;
        var index = Random.Range(0, list.Count);
        return list[index];
    }

    public static Rect GetOrthographicBounds(this Camera camera)
    {
        float screenAspect = (float)camera.pixelWidth / (float)camera.pixelHeight;
        float cameraHeight = camera.orthographicSize * 2;
        var size = new Vector2(cameraHeight * screenAspect, cameraHeight);
        var bounds = new Rect(
            (Vector2)camera.transform.position - size * .5f,
            size
            );
        return bounds;
    }
}


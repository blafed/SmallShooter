using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl current { get; private set; }

    public new Camera camera { get; private set; }


    Transform offsetTransform;
    Transform shakerTransform;

    public Vector2 center
    {
        get => transform.position;
        set => transform.position = value;
    }
    public Vector2 offset
    {
        get => offsetTransform.position;
        set => offsetTransform.position = value;
    }

    private void Awake()
    {
        current = this;
        camera = GetComponentInChildren<Camera>();
        offsetTransform = transform.GetChild(0);
        shakerTransform = offsetTransform.GetChild(0);
    }






}
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl current { get; private set; }
    public CameraFollow cameraFollow { get; private set; }
    public new Camera camera { get; private set; }

    public Rect rect
    {
        get
        {

            var aspectRatio = Screen.width / (float)Screen.height;
            var height = camera.orthographicSize * 2;
            var size = new Vector2(aspectRatio * height, height);

            return new Rect(center + size / 2, size);
        }
    }

    public float audioMaxDistance = 20;


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
        cameraFollow = GetComponent<CameraFollow>();
        offsetTransform = transform.GetChild(0);
        shakerTransform = offsetTransform.GetChild(0);
    }






}
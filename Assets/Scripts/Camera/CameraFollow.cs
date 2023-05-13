using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 4;
    public float maxEscapeDistance = 2;
    public float turboSpeed = 2;
    public Vector2 offset = new Vector2(0, 0);
    CameraControl cameraControl;



    private void Awake()
    {
        cameraControl = GetComponent<CameraControl>();
    }
    private void FixedUpdate()
    {
        if (target)
        {
            var targetPosition = target.position + (Vector3)offset;
            var diff = (Vector2)target.position - cameraControl.center;

            if (diff.sqrMagnitude < maxEscapeDistance.Squared())
                cameraControl.center = Vector2.Lerp(cameraControl.center, targetPosition, Time.fixedDeltaTime * speed);
            else
                cameraControl.center = Vector2.Lerp(cameraControl.center, targetPosition, Time.fixedDeltaTime * turboSpeed);
        }
    }
}
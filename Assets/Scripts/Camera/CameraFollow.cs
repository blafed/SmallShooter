using UnityEngine;

namespace SmallShooter.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public float speed = 4;
        public Vector2 offset = new Vector2(0, 0);
        CameraControl cameraControl;

        private void Awake()
        {
            cameraControl = GetComponent<CameraControl>();
        }
        private void Update()
        {
            if (target)
            {
                cameraControl.center = Vector2.Lerp(cameraControl.center, target.position + (Vector3)offset, Time.deltaTime * speed);
            }
        }
    }
}
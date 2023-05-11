using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Vector2 movement;
    public Vector2 lookDirection;
    public bool isAttack;


    private void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        UpdateLookDirection();
        isAttack = Input.GetButton("Fire1");
    }


    void UpdateLookDirection()
    {
        var cameraControl = CameraControl.current;
        var worldMousePos = (Vector2)cameraControl.camera.ScreenToWorldPoint(Input.mousePosition);
        var cameraCenter = cameraControl.center;

        var diff = worldMousePos - cameraCenter;
        lookDirection = diff.normalized;

    }
}

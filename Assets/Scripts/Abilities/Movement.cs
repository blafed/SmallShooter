using UnityEngine;

/// <summary>
/// Movement component for any unit
/// </summary>
public class Movement : Ability
{
    public float speed = 3;
    public Vector2 inputMovement;


    private void FixedUpdate()
    {
        transform.Translate(speed * inputMovement * Time.fixedDeltaTime);
    }

}
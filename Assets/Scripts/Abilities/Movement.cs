using UnityEngine;

/// <summary>
/// Movement component for any unit
/// </summary>
public class Movement : Ability
{
    public enum Mode
    {
        Translate,
        Velocity,
    }
    public Mode mode;
    public float speed = 3;
    [SerializeField]
    Vector2 _inputMovement;


    Rigidbody2D rb;


    public bool isMoving => inputMovement.sqrMagnitude > .001f;
    public Vector2 inputMovement => _inputMovement;

    private void OnValidate()
    {
        if (mode == Mode.Velocity)
            if (!GetComponent<Rigidbody2D>())
                Debug.LogError($"Movement mode {mode} requires Rigidbody2D on " + this, this);
    }

    protected override void Awake()
    {
        base.Awake();

        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (mode == Mode.Translate)
            transform.Translate(speed * inputMovement * Time.fixedDeltaTime, Space.World);
        if (mode == Mode.Velocity)
            rb.velocity = speed * inputMovement;
    }

    public void SetMovement(Vector2 direction)
    {
        _inputMovement = direction;
        if (mode == Mode.Velocity)
            rb.velocity = speed * inputMovement;
    }
    public void Stop()
    {
        SetMovement(Vector2.zero);
    }

}
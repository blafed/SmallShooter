using UnityEngine;

public class DamagingTrigger : DamagingInteract
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Interact(other);
    }
}
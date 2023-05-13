using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float delay = 1f;


    private void Start()
    {
        Destroy(gameObject, delay);
    }
}
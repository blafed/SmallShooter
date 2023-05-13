using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolume2D : MonoBehaviour
{
    AudioSource audioSource;

    float startVolume;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startVolume = audioSource.volume;
    }

    void Update()
    {
        if (!camera)
            camera = Camera.main;
        if (!Camera.main.GetOrthographicBounds().Contains(transform.position))
        {
            audioSource.volume = 0;
        }
        else
        {
            audioSource.volume = startVolume;
        }
    }

    new static Camera camera;


    // private void OnDrawGizmos()
    // {
    //     Gizmos.color
    //     = Color.red;
    //     Gizmos.DrawCube(Camera.main.GetOrthographicBounds().center, Camera.main.GetOrthographicBounds().size);
    // }

}
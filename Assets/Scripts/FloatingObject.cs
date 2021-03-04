using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    [Range(0f, 10f)][SerializeField] private float speed = 1f;
    [Range(0f, 1f)][SerializeField] private float amplitude = 0.15f;

    private Vector3 origin;

    
    void Start()
    {
        origin = transform.position;
    }

    
    void Update()
    {
        transform.position = new Vector3(transform.position.x,
            origin.y + Mathf.Sin(Time.fixedTime * Mathf.PI * speed) * amplitude,
            transform.position.z);
    }
}

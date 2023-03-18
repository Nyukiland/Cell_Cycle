using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followSmooth : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void FixedUpdate()
    {
        float smoothtime2 = smoothTime *2* Mathf.Sqrt(Vector3.Distance(transform.position, target.position));

        Vector3 newPosition = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothtime2);
        rb.MovePosition(newPosition);
    }
}

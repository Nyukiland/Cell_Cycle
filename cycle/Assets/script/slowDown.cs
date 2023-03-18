using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowDown : MonoBehaviour
{
    public bool needSlow;
    Rigidbody rb;

    private void Start()
    {
        needSlow = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (needSlow)
        {
            rb.velocity = rb.velocity * 0.95f;
        }
    }
}

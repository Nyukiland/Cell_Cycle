using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveback : MonoBehaviour
{
    [SerializeField] Light Lsource;
    Vector3 startPos;
    [SerializeField] Vector3 offset;

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 rotationLight = Lsource.transform.eulerAngles;

        Vector3 direction = -Vector3.forward;

        direction = Quaternion.AngleAxis(rotationLight.x, Vector3.right) * direction;
        direction = Quaternion.AngleAxis(rotationLight.y, Vector3.up) * direction;
        direction = Quaternion.AngleAxis(rotationLight.z, Vector3.forward) * direction;

        Vector3 Toffset = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z + offset.z);

        Ray lightRay = new Ray(Toffset, direction.normalized);
        RaycastHit lightHit;
        if (Physics.Raycast(lightRay, out lightHit))
        {
            
        }
        else
        {
            transform.position = startPos;
        }
    }
    /*
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("layerScene")) transform.position = startPos;
    }
    */
}

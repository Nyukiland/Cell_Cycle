using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfLight : MonoBehaviour
{
    [SerializeField] Light Lsource;
    [SerializeField] Vector3 offset;

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
        if (Physics.Raycast(lightRay, out lightHit, Mathf.Infinity))
        {
            //Debug.DrawRay(lightRay.origin, lightHit.point - lightRay.origin, Color.yellow);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowRaycast : MonoBehaviour
{
    [SerializeField] Light Mlight; // Reference to the light game object
    [SerializeField] GameObject cell; // Reference to the game object that will follow the hit point
    [SerializeField] LayerMask layerScene;

    [Space]

    [SerializeField] float maxRotation;
    [SerializeField] float minRotation;
    [SerializeField] float speedRota;
    float rotation;
    [SerializeField] Vector3 offset;

    Vector3 rotationLight;


    private void Start()
    {
        rotation = (minRotation + (minRotation + maxRotation) / 2);
        Mlight.transform.eulerAngles =new Vector3(Mlight.transform.eulerAngles.x, rotation, Mlight.transform.eulerAngles.z);
        rotationLight = Mlight.transform.eulerAngles;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            if (rotation < maxRotation)
            {
                Mlight.transform.eulerAngles += new Vector3(0, speedRota, 0);
                rotation += speedRota;
            }
        }
        else if (!Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            if (rotation > minRotation)
            {
                Mlight.transform.eulerAngles += new Vector3(0, -speedRota, 0);
                rotation -= speedRota;
            }
        }
        else if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            rotationLight = Mlight.transform.eulerAngles;

            // Draw a raycast from the camera to the mouse position
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit cameraHit;
            if (Physics.Raycast(cameraRay, out cameraHit, Mathf.Infinity, layerScene))
            {
                //Debug.DrawRay(cameraRay.origin, cameraHit.point - cameraRay.origin, Color.red);

                //Draw Raycast from sphere to light
                Vector3 direction = -Vector3.forward;

                direction = Quaternion.AngleAxis(rotationLight.x, Vector3.right) * direction;
                direction = Quaternion.AngleAxis(rotationLight.y, Vector3.up) * direction;
                direction = Quaternion.AngleAxis(rotationLight.z, Vector3.forward) * direction;

                Vector3 Toffset = new Vector3(cameraHit.point.x + offset.x, cameraHit.point.y + offset.y, cameraHit.point.z + offset.z);

                Ray lightRay = new Ray(Toffset, direction.normalized);
                RaycastHit lightHit;
                if (Physics.Raycast(lightRay, out lightHit, Mathf.Infinity, layerScene))
                {
                    //Debug.DrawRay(lightRay.origin, lightHit.point - lightRay.origin, Color.green);
                    if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                    {
                        // Check if both raycasts are not touching the same point
                        if (lightHit.point != null)
                        {
                            // Move the target game object to the hit point of the camera raycast
                            cell.transform.position = cameraHit.point;
                        }
                        else if (lightHit.point == null)
                        {
                            // hit by light
                            transform.position = transform.position;
                        }
                    }
                }

            }
        }
    }
}

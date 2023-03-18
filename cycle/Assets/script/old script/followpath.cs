using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followpath : MonoBehaviour
{
    public Transform objectToFollow;
    public float speed = 2f;

    private List<Vector3> path = new List<Vector3>();

    void Update()
    {
        // record position of the object to follow
        path.Add(objectToFollow.position);

        // remove oldest point if path gets too long
        if (path.Count > 1000) // adjust maximum length based on your needs
        {
            path.RemoveAt(0);
        }

        // follow the path
        if (path.Count > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, path[path.Count - 2], speed * Time.deltaTime);
        }
    }
}

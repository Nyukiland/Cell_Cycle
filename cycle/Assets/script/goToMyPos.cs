using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToMyPos : MonoBehaviour
{
    [SerializeField] float speed = 35;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("cell"))
        {
            other.gameObject.GetComponent<slowDown>().needSlow = false;
            other.gameObject.GetComponent<Rigidbody>().AddForce((transform.position - other.gameObject.transform.position) * speed , ForceMode.Force);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("cell"))
        {
            other.gameObject.GetComponent<slowDown>().needSlow = true;
        }
    }
}

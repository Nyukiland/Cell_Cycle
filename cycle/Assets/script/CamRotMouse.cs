using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotMouse : MonoBehaviour
{
    Vector3 rotaNormal;

    void Start()
    {
        rotaNormal = transform.eulerAngles;
    }

    
    void Update()
    {
        //2.5 rotation max qui semblent non genante
        //plus grand vers le haut == soustraire pour la rota

        Vector2 mousePosCentered = new Vector2(Input.mousePosition.x - (Screen.width/2), Input.mousePosition.y - (Screen.height/2));

        float transformX = rotaNormal.x - (2.5f * (mousePosCentered.y / (Screen.width / 2)));
        float transformY = rotaNormal.y + (2.5f * (mousePosCentered.x / (Screen.height / 2)));

        transform.eulerAngles = new Vector3(transformX, transformY, rotaNormal.z);
    }
}

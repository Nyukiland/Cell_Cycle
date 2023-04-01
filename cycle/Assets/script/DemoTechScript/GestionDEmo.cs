using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionDEmo : MonoBehaviour
{
    bool isMenu = false;
    bool isCreation = false;

    [Space]

    [SerializeField] GameObject interfaceC;
    [SerializeField] GameObject Cam;
    [SerializeField] GameObject MainCell;
    [SerializeField] LayerMask layerScene;

    [Space]

    [SerializeField] GameObject cube;
    [SerializeField] GameObject cubePrefab;
    [SerializeField] Color newColor;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            isMenu = !isMenu;
        }

        if (Input.GetButtonDown("Jump"))
        {
            isCreation = !isCreation;
        }

        //menu
        if (isMenu)
        {
            interfaceC.SetActive(true);
            Cam.GetComponent<CamRotMouse>().enabled = false;
            Time.timeScale = 0;
            
        }
        else
        {
            Time.timeScale = 1;
            Cam.GetComponent<CamRotMouse>().enabled = true;
            interfaceC.SetActive(false);
        }


        //mode de jeu
        if(isCreation)
        {
            Cam.GetComponent<ShadowRaycast>().enabled = false;
            MainCell.GetComponent<followSmooth>().enabled = false;
            MainCell.GetComponent<Rigidbody>().isKinematic = true;

            cube.SetActive(true);

            cube.transform.localScale += new Vector3(Input.mouseScrollDelta.y, Input.mouseScrollDelta.y*2, Input.mouseScrollDelta.y) * 0.05f;

            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit cameraHit;
            if (Physics.Raycast(cameraRay, out cameraHit, Mathf.Infinity, layerScene))
            {
                cube.transform.position = cameraHit.point;

                if (Input.GetMouseButtonDown(0))
                {
                    if (cameraHit.collider.CompareTag("CanDestroy"))
                    {
                        Destroy(cameraHit.collider.gameObject);
                    }
                    else
                    {
                        GameObject clone = Instantiate(cubePrefab, cube.transform.position, Quaternion.identity);
                        clone.transform.localScale = cube.transform.localScale;
                    }
                }
                
            }
        }
        else
        {
            Cam.GetComponent<ShadowRaycast>().enabled = true;
            MainCell.GetComponent<followSmooth>().enabled = true;
            MainCell.GetComponent<Rigidbody>().isKinematic = false;

            cube.SetActive(false);
        }

        if (Input.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene(0);
        }
    }
}

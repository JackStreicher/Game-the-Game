using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camSwitchSecondFloor : MonoBehaviour
{

    private GameObject player;
    public Camera buildingCam;
    public GameObject cam;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        buildingCam.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            buildingCam.enabled = true;
            cam.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //player.GetComponentInChildren<Camera>().enabled = true;
            cam.SetActive(true);
            buildingCam.enabled = false;
        }
    }
}

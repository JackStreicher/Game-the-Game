using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeActivateDoor : MonoBehaviour
{
    public GameObject cube;
    public Animator animMaster;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == cube)
        {
            animMaster.SetTrigger("open");
            Debug.Log("Cube is in it");
        }
    }
}

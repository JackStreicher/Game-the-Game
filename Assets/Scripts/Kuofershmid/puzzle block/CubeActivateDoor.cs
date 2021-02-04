using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeActivateDoor : MonoBehaviour
{
    public GameObject cube;
    public Animator doorAnim;
    public Animation doorAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == cube)
        {
            doorAnim.Play("DoorOpen");
            Debug.Log("Cube is in it");
        }
    }
}

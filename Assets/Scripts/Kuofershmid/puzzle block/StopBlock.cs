using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBlock : MonoBehaviour
{
    public string BadOBJTag;
    public GameObject shutDown;

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
        if(other.tag == BadOBJTag)
        {
            shutDown.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == BadOBJTag)
        {
            shutDown.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackRay : MonoBehaviour
{
    public float rayDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
       if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 50f))
       { 

           Debug.DrawRay(new Vector3(0, 0, 0), new Vector3(2f, 0f, 0f), Color.white);
       }

        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 20f))
        //{
        //    if (hit.collider.tag == "Player")
        //    {
        //
        //
        //        Debug.Log("attack");
        //    }
        //    else
        //    {
        //
        //    }
        //    Debug.DrawRay(new Vector3(0, 0, 0), new Vector3(2f, 0f, 0f), Color.red);
        //}
 

      //if (Physics.Raycast(transform.position, Vector3.forward, out hit, rayDistance))
      //{
      //    Debug. DrawRay(transform.position, hit.point,  Color.red);
      //    
      //}

    }
}

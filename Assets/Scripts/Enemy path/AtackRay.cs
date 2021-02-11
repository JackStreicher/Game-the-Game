using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackRay : MonoBehaviour
{
    public float rayDistance;
    public Animator anim;
    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
       
        RaycastHit hit;
        LayerMask enemyLayer = LayerMask.GetMask("Enemy");
        LayerMask playerLayer = LayerMask.GetMask("Player");
       if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance))
       {
            Debug.Log(hit);
            Debug.Log("awefertetertE$TERT");
            if (hit.transform.gameObject.layer == 8)
            {
                Attack();



                Debug.Log("attack");
            }
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);



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

    public void Attack()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
        anim.SetBool("Attack", true);
    }
}

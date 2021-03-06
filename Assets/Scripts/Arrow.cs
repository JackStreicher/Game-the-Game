﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Arrow : MonoBehaviour
{
    Rigidbody rb;

    //Longow Power: 400-480 Newtonwww
    public float basePower = 80f;
    protected float power;

    protected float damage;

    public Transform parentTrans;

    Vector3 v1; //previous pos
    Vector3 v2; //current Pos
    protected RaycastHit hit;

    bool flying;


    Vector3 direction;
    // Start is called before the first frame update
    public virtual void Start()
    {
        
        power = basePower;
        rb = GetComponent<Rigidbody>();
        rb.transform.GetComponent<CapsuleCollider>().enabled = false;
        rb.useGravity = false;
        damage = power; // * rb.mass;        
        rb.centerOfMass = gameObject.transform.localPosition + new Vector3(0, 0, 1.15f);
        v1 = transform.position;
    }
    

    public virtual void Fire(Vector3 dir)
    {
        damage = power;
        StartCoroutine(FireCo(dir));
     
    }

    public virtual IEnumerator FireCo(Vector3 tar)
    {
        parentTrans = null;
        transform.LookAt(tar);
        //Debug.Log(tar);
        rb.AddForce(transform.forward * power * 1.2f, ForceMode.Impulse);
        //Debug.Log("Power" + power);
        //rb.AddTorque(transform.forward * 80, ForceMode.Impulse);
        //transform.Rotate(-15, 0, 0);
        rb.useGravity = true;
        
        
        yield return new WaitForSeconds(0.05f);
        v1 = transform.position;
        rb.transform.GetComponent<CapsuleCollider>().enabled = true;
        flying = true;
    }

    protected virtual void FixedUpdate()
    {
        //The Arrow dips its head towards the Velocity vector
        if (rb.velocity != Vector3.zero)
            rb.rotation = Quaternion.LookRotation(rb.velocity);

       //if (flying)
       //{
       //
       //    v2 = transform.position;
       //    Ray ray = new Ray(v1, v2);
       //    if (Physics.Raycast(ray, out hit, Vector3.Distance(v2, v1), 11))
       //    {
       //        if (hit.transform.gameObject.layer == 10)
       //        {
       //            flying = false;
       //            transform.position = hit.transform.position;
       //            this.transform.SetParent(hit.transform);
       //
       //            Debug.Log("Hit1");
       //            if (hit.transform.GetComponent<NPCStats>())
       //            {
       //                Debug.Log("Hit");
       //                hit.transform.GetComponent<NPCStats>().SufferDamage(damage, GameObject.Find("Player").GetComponent<Stats>());
       //            }
       //        }
       //
       //    }
       //    v1 = v2;
       //}
    

        //CheckCollision();
        if (parentTrans != null)
        {
            transform.rotation = parentTrans.rotation * Quaternion.Euler(-90f, 0, 0);
            this.transform.position = parentTrans.position;
        }
    }


    //public void CheckCollision()
    //{
    //    RaycastHit hit;
    //    // Does the ray intersect any objects excluding the player layer
    //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f))
    //    {
    //        if (hit.transform.GetComponent<NPCStats>())
    //        {
    //            hit.transform.GetComponent<NPCStats>().SufferDamage(damage, GameObject.Find("Player").GetComponent<Stats>());
    //            rb.useGravity = false;
    //            rb.isKinematic = true;
    //            this.transform.SetParent(hit.transform);
    //            this.transform.position += transform.forward * 3f;
    //
    //            
    //        }
    //
    //        else
    //        {
    //            StartCoroutine(Remover.DelayAndRemove(this.transform.gameObject, 2));
    //        }
    //    }
    //}

    protected void OnCollisionEnter(Collision collision)
    {
    
        //rb.useGravity = true;
        //rb.transform.GetComponent<SphereCollider>().enabled = false;
        if (collision.transform.GetComponent<NPCStats>())
        {
            damage = power;
            collision.transform.GetComponent<NPCStats>().SufferDamage(damage, GameObject.FindWithTag("Player").GetComponent<Stats>());

            rb.useGravity = false;
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            
            this.transform.position += transform.forward * power / 250; //depth of being stuck inside the NPC/wall
            this.transform.SetParent(collision.transform);
           
            
    
            //Debug.Log("Hit Target Enemy" + damage);
        }
        else
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            this.transform.position += transform.forward * power / 250; //depth of being stuck inside the NPC/wall
            this.transform.SetParent(collision.transform);

        }
    }
    

  
    public void SetProjectilePower(float newPower)
    {

        power = newPower;
        damage = power * 3/4;

    }
    public float GetProjectilePower()
    {

        return power;

    }


}





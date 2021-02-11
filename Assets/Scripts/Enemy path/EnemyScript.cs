using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float attackTime;
    public float speed;
    public Transform player;
    public GameObject rayPoint;
    Animator anim;
    float resetSpeed;
    float removeSpeed;
    bool isInVision;
    bool isAttack;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        removeSpeed = 0;
        anim = gameObject.GetComponent<Animator>();
        resetSpeed = speed;
        player = GameObject.FindWithTag("Player").transform;
        anim.SetBool("Idle", true);
        anim.SetBool("Attack", false);
        anim.SetBool("Walk", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isInVision == true)
        {
            anim.SetBool("Idle", false);
            lookAtPlayer();
            FollowPlayer();
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
        }


       



    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isInVision = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isInVision = false;
        }
    }

    public void FollowPlayer()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        anim.SetBool("Walk", true);
    }

    public void lookAtPlayer()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), Vector3.up);
        //Debug.Log(player.transform.position);
    }

    public IEnumerator AttackStade()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Attack", true);
        speed = removeSpeed;
        yield return new WaitForSeconds(attackTime);
        speed = resetSpeed;
        isAttack = false;

    }
}

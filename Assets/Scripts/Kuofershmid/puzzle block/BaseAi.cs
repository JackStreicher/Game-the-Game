using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAi : MonoBehaviour
{
    public float speed;
    public Transform player;
    public GameObject player_OBJ;
    public Rigidbody rigi;
    bool isInVision = false;

    public void Start()
    {
        //finde player
        player = GameObject.FindWithTag("Player").transform;
        //Debug.Log("Got the playre");
    }

    // Update is called once per frame
    void Update()
    {
        if (isInVision == true)
        {
            lookAtPlayer();
        }


        



    }
    //schaut auf den player
    public void lookAtPlayer()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), Vector3.up);
        //Debug.Log(player.transform.position);
        //bewegt gegner vorwärtz
        transform.position += transform.forward * speed * Time.deltaTime;
    }

}

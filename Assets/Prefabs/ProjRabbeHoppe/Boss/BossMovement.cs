using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossMovement : MonoBehaviour
{
    public GameObject Boss;
    public Vector3 actualMove;
    public float speed;
    public float rx;
    public float rz;
    public CharacterController controller;
    System.Random rand;
    public int count = 0;
    public int max_count = 400;
    public GameObject player;

    float slow = 0f; //will be declared at the top later

    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rx = (float)Math.Round((float)rand.NextDouble() * 10) - 5;
        rz = (float)Math.Round((float)rand.NextDouble() * 10) - 5;

        //checking for diagonal movement
        if (rx > 0 && rz < 0 || rx < 0 && rz > 0 || rx < 0 && rz < 0 || rx > 0 && rz > 0)
        {
            slow = speed * 33.333f;
        }


        // Movement Time
        if (count > max_count)
        {
            // if to much outside from Bossarea
            if (this.transform.position.x > -149)
            {
                rx = -10;
                if (this.transform.position.z > 1850)
                {
                    rz = 10;
                }
                else if (this.transform.position.z < 1792)
                {
                    rz = -10;
                }
            }
            else if (this.transform.position.x < -167)
            {
                rx = 10;
                if (this.transform.position.z > 1850)
                {
                    rz = 10;
                }
                else if (this.transform.position.z < 1792)
                {
                    rz = -10;
                }
            }
            //Move
            actualMove = transform.right * rx * (speed - slow) //Left - right
                        + transform.forward * rz * (speed - slow); // forward, backwards
            controller.Move(actualMove * Time.deltaTime);

            count = 0;
        }
        count++;
        
    }
}

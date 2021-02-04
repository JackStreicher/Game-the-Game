using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    private float speedModifier;

    public float jumpPower;

    //Getting all the Components we need from the Player-Empty
    public Rigidbody playerRB;
    //private CapsuleCollider playerCollider;
    public CharacterController controller;

    public Vector3 velocity;
    public bool isGroundedPlayer { get; private set; }

    public Vector3 move { get; private set; }

    public float fallSpeed {get; private set;}

    private float prevPosY = 0;

    public void Start()
    {
        //Put this into a file that's loaded on Startup of the Scene
        Physics.gravity = new Vector3(0, -30, 0);

        //Gets components from the Parent-GameObject, which is the Empty containing the Rigidbody and the Collider
        //playerMovement = controller.transform.GetComponent<Rigidbody>();
        //playerCollider = this.transform.parent.GetComponent<CapsuleCollider>();



        //Load these via PlayerConfig Scriptable Object
        speed = 6f;
        speedModifier = 1.5f;

        //jumpPower = 2f;
        prevPosY = transform.position.y;
    }

    public void FixedUpdate()
    {
        //Movement();
        //IsGrounded();
        Fallspeed();
       
    }


    public void Update()
    {
        Movement();



        isGroundedPlayer = controller.isGrounded;

        if (isGroundedPlayer && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            Jump();

        }



       
    }
   
    //put into fixedUpdate
    public void Fallspeed()
    {
        var distance = Math.Abs(prevPosY - transform.parent.position.y);
        fallSpeed = distance;

        prevPosY = fallSpeed;
    }

   


    public void Movement()
    {
        

        float slow = 0f; //will be declared at the top later

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //<- an dieser Stelle kommt noch eine Abfrage, ob wir fallen oder nicht

       //if (!controller.isGrounded)
       //{
       //    slow = speed * 0.2f; // sets slow to be 1/2 of the speed while falling/jumping
       //}
       //else
       //{
       //    slow = 0; //no slow
       //}

        //Movement Left-Right Forwards-Backwards
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //maximum range for walking
            move = transform.right * x * ((speed - slow) * speedModifier) //Left - right
                    + transform.forward * z * ((speed - slow) * speedModifier - slow); // forward, backwards
                     // gravity

            

            //move = transform.right * x * ((speed - slow) * speedModifier ) //Left - right
            //        + transform.forward * z * ((speed - slow) * speedModifier - slow) // forward, backwards
            //        + transform.up * playerMovement.velocity.y; // gravity
            //
            //set the Speed of the RigidBody
            //playerMovement.velocity = move;
            
           

            // transform right = New Vector3(1, 0, 0)  wenn mit x (Wert zwischen 1 und -1) multipliziert 
            //= New Vector3(1 * x, 0, 0)
            // Wenn wir jetzt sagen: transform.right + transform.forward 
            //= new Vector3(1,0,0) + new Vector3(0,0,1) ==> new Vector3(1,0,1)
        }
        else
        {
           
            //checking for diagonal movement
            if (x > 0 && z <  0 || x < 0 && z > 0 || x < 0 && z < 0 ||x > 0 && z > 0)
            {
                slow = speed * 0.333f;
            }
            move = transform.right * x * (speed - slow) //Left - right
                    + transform.forward * z * (speed - slow); // forward, backwards
                    // gravity


            

            //move = transform.right * x * (speed - slow) //Left - right
            //        + transform.forward * z * (speed - slow) // forward, backwards
            //        + transform.up * playerMovement.velocity.y; // gravity
            //
            //playerMovement.velocity = move;



        }

        //Debug.Log("Moving " + move);

        velocity.y +=  3f * -9.81f * Time.deltaTime;
        controller.Move((move + velocity ) * Time.deltaTime);
    }


    public void Jump()
    {
        //Jump


        //playerMovement.velocity += transform.up * jumpPower;
        velocity.y += Mathf.Sqrt(jumpPower * -3.0f * -9.81f);
        
            
        
    }

    /*
    public void IsGrounded()
    {
    
        float colliderHeight = playerCollider.bounds.size.y; //Gets the half-height of the capsule collider (which is 1 in this case)

        Vector3 colliderPos = playerCollider.center; //Pivot-Point of the Collider (Local Position)

        Vector3 colliderWorldPos = playerCollider.transform.TransformPoint(colliderPos); //converts to World-Space   

        //Sending the Raycast from the Feet of the Collider
        var feetPosition = new Vector3(colliderWorldPos.x, colliderWorldPos.y - (colliderHeight - 0.005f)/2, colliderWorldPos.z);



        RaycastHit hit;

        
        if (Physics.Raycast(feetPosition, Vector3.down, out hit, Mathf.Infinity))
        {
           
            //Debug.DrawRay(feetPosition, Vector3.down, Color.red, Mathf.Infinity);
            
            if (hit.distance > 0.05f)
            {

                isGrounded = false;
                

            }
          
            else if(hit.distance <= 0.05f)
            {
                
                //We are close enough to the ground
              
                isGrounded = true;
                
                
               
            }
        }
        else
        {
            //Debug.Log("Infinity");
            //ray hits nothing --> we are falling --> isGrounded == false
            isGrounded = false;
          
          
        }


    }
    */
}

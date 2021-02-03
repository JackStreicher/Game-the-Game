using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{

    Animator anim;
    public PlayerMovement playerMovement;
    Vector3 playerspeed;
    

    int jumpHash = Animator.StringToHash("Jump");
    int xHash = Animator.StringToHash("X");
    int yHash = Animator.StringToHash("Y");
    int randomHash = Animator.StringToHash("Random");
    int combatStateHash = Animator.StringToHash("isCombat");
  



    int takeAim = Animator.StringToHash("TakeAim");
    int hold = Animator.StringToHash("Hold");
    int fire = Animator.StringToHash("Fire");
    int cancelAttack = Animator.StringToHash("CancelAttack");

    //public int amountOfIdleAnimationss = 3;

    int counter = 0;
    float prevNr = 0;
    float currentNr = 0;
    float lerping;
    float timeElapsed = 0;
    float lerpDuration = 3f;

    bool isAttackStarted = false;
    bool isHolding = false;


    GameObject projectileRef;

    public bool isCombat { get; set; } = false;


    int fallCounter = 0;

    //int runHash = Animator.StringToHash("Jump");

    public void Start()
    {
        anim = transform.GetComponent<Animator>();
       
        //anim.SetLayerWeight(1, 0);
        //anim.SetFloat(randomHash, 1);

    }


    public void FixedUpdate()
    {
        if (!playerMovement.isGroundedPlayer)
        {
            fallCounter++;
            if (fallCounter >= 80)
            {
                anim.SetBool("isFalling", true);
                fallCounter = 0;
            }
        }
        else
        {
            anim.SetBool("isFalling", false);
            fallCounter = 0;
        }
    }


    // Update is called once per frame
    void Update()
    {

        float playerVelocity = playerMovement.move.magnitude;










        if (anim != null)
        {

            float y  = Input.GetAxis("Vertical");
            float x = Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.LeftShift))
            {
                x = Mathf.Clamp(x, -1f, 1f);
                y = Mathf.Clamp(y, -1f, 1f);
            }
            else
            {

                x = Mathf.Clamp(x, -0.5f, 0.5f);
                y = Mathf.Clamp(y, -0.5f, 0.5f);
            }







            anim.SetFloat(xHash, x);
            anim.SetFloat(yHash, y);

           

            anim.SetFloat("Speed", playerVelocity);


            if (Input.GetKeyDown(KeyCode.Space) && playerMovement.isGroundedPlayer)
            {
                anim.SetTrigger(jumpHash);

                
            }

          

           // if (Input.GetKey(KeyCode.A))
           // {
           //     anim.SetBool("StrafeRight", true);
           //
           // }


            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                if (isCombat)
                {
                    isCombat = false;
                    anim.SetBool(combatStateHash, isCombat);
                }
                else
                {
                    isCombat = true;
                    anim.SetBool(combatStateHash, isCombat);
                }
            }
        }



    }

    
}

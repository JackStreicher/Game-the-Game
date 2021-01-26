using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{

    Animator anim;
    Rigidbody playerRB;
    

    int jumpHash = Animator.StringToHash("Jump");
    int xHash = Animator.StringToHash("X");
    int yHash = Animator.StringToHash("Y");
    int randomHash = Animator.StringToHash("Random");
    int combatStateHash = Animator.StringToHash("isCombat");
  



    int takeAim = Animator.StringToHash("TakeAim");
    int hold = Animator.StringToHash("Hold");
    int fire = Animator.StringToHash("Fire");
    int cancelAttack = Animator.StringToHash("CancelAttack");

    public int amountOfIdleAnimationss = 3;

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

    //int runHash = Animator.StringToHash("Jump");

    public void Start()
    {
        anim = transform.GetComponent<Animator>();
        playerRB = GameObject.Find("Player").GetComponent<Rigidbody>();
        anim.SetLayerWeight(1, 0);
        //anim.SetFloat(randomHash, 1);

    }



    // Update is called once per frame
    void Update()
    {
        



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

            float move = playerRB.velocity.magnitude;

            anim.SetFloat("Speed", move);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger(jumpHash);
            }

          

            if (Input.GetKey(KeyCode.A))
            {
                anim.SetBool("StrafeRight", true);

            }


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

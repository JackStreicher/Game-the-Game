using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class NPCBehaviour : MonoBehaviour
{

    public enum State
    {
        NonCombat,
        Combat,
        Death
    }

    CharacterController controller;
    public OrlagAnimationController animationConrollerScript;
    public GameObject target;
    public State state;
    public float speed;
    protected Animator anim;


    protected bool isCountDown;
    protected int counter = 0;
    protected int timeUntilIdle = 40; //50 frames == 1 second == 1,2 frames per second
    protected bool isIdle;

    float attackSpeed;
    private bool weaponState;
    bool isAttacking;

    private float health;
    protected Transform oldPosition;




    // Start is called before the first frame update
    void Start()
    {
        state = State.NonCombat;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        target = null;
        oldPosition = transform;

        health = GetComponent<NPCStats>().hitpoints;
        Move(false);


    }

    protected void FixedUpdate()
    {
        if (isCountDown)
        {
            if (counter < timeUntilIdle)
            {
                counter++;
                isIdle = false;
            }
            else
            {
                counter = 0;
                isIdle = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var currentHitpoints = GetComponent<NPCStats>().hitpoints;
        //Health-Change-Check
        if (currentHitpoints < health)
        {
            animationConrollerScript.TakingDamage();
            Debug.Log("Ouch!");
            health = currentHitpoints;
        }



        if (isAttacking)
        {
            GetComponent<NPCWeapon>().wStats.isAttacking = true;
        }
        else
        {
            GetComponent<NPCWeapon>().wStats.isAttacking = false;
        }

        if (GetComponent<NPCStats>().hitpoints <= 0)
        {
            state = State.Death;
            //GetComponent<CapsuleCollider>().enabled = false;
            controller.detectCollisions = false;
            
        }
        //State Handling
        if (state == State.NonCombat)
        {
            GetComponent<NPCStats>().Heal(500f);
            TurnToTarget(oldPosition);
            isCountDown = true;

            if (isIdle)
            {
                animationConrollerScript.Idle();
            }
            var dist = Vector3.Distance(oldPosition.position, transform.position);
            if (dist > 100f)
            {
                if (dist > 15f)
                {
                    animationConrollerScript.Run();
                    Move(true);
                }
                else
                {
                    animationConrollerScript.Walk();
                    Move(false);
                }
            }

        }

        if (state == State.Combat)
        {
            isCountDown = false;

            TurnToTarget(target.transform);
            var dist = Vector3.Distance(transform.position, target.transform.position);
            //Debug.Log("Distance " + dist);
            if (dist > 3.4f)
            {

                animationConrollerScript.Run();
                Move(true);

                if (dist >= 60f)
                {
                    Debug.Log("true");
                    Move(true);
                    state = State.NonCombat;
                }
            }

            else
            {
                //AttackTimer
                if (!isAttacking)
                {
                    animationConrollerScript.CombatStance();
                    Debug.Log("attack");
                    isAttacking = true;
                    StartCoroutine(AttackTiming(attackSpeed));
                }
            }
        }

        if (state == State.Death)
        {
            //DeathLogic
            animationConrollerScript.Death();
            //GetComponent<ItemDrop>().DropItems();
        }

    }

    protected virtual void TurnToTarget(Transform targetPos)
    {
        if (target != null)
        {
            Quaternion lookOnLook = Quaternion.LookRotation(targetPos.position - new Vector3(transform.position.x, targetPos.position.y, transform.position.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, Time.deltaTime * 4f);
        }

    }

    protected virtual void Move(bool isRunning)
    {
        if (!isRunning)
            controller.Move(transform.forward * speed * Time.deltaTime + Vector3.up * -9.81f);
        else
        {
            controller.Move(transform.forward * speed * 1.25f * Time.deltaTime + Vector3.up * -9.81f);
        }
    }

    protected virtual IEnumerator AttackTiming(float speedOfAttack)
    {
        var animLayer = anim.GetLayerIndex("Attack");
        yield return new WaitForSeconds(speedOfAttack); //delay until the attack starts


        animationConrollerScript.Attack();
        var durationOfAnimClip = anim.GetCurrentAnimatorStateInfo(animLayer).length; //assuming a framerate of 60

        yield return new WaitForSeconds(durationOfAnimClip * 1.4f);
        isAttacking = false;

    }

    protected virtual IEnumerator GetVariables()
    {
        yield return new WaitForSeconds(1.5f);
        if (GetComponent<NPCWeapon>() != null)
        {
            attackSpeed = GetComponent<NPCWeapon>().wStats.speed;
            weaponState = GetComponent<NPCWeapon>().wStats.isAttacking;
        }
        else
        {
            Debug.Log("NPC Behaviour cannot access the weapon. Is the NPC unarmed?");
        }

        //controller.Animation

    }

    //public virtual IEnumerator AttackSpeedDelay(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //
    //    //weaponState = false;      
    //   
    //}

    protected virtual void OnTriggerEnter(Collider other)
    {
        //
        // LayerMask enemy = LayerMask.GetMask("Enemy");
        // LayerMask terrain = LayerMask.GetMask("Terrain");
        // LayerMask untagged = LayerMask.GetMask("Untagged");
        // LayerMask player = LayerMask.GetMask("Player");
        if (other.transform.gameObject.tag == "Player")
        {
            Debug.Log("Enter Trigger " + other.gameObject.name);

            target = other.gameObject;
            state = State.Combat;
        }

    }

    public virtual void SetTargetAndEnterCombat(GameObject newTarget)
    {
        if (newTarget != null)
        {
            target = newTarget;
            state = State.Combat;
        }

    }
}

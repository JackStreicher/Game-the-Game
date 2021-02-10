using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    private Stats playerStats;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrollieren
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkpointRange;

    //Attacking
    public float timeBetweenAttacks;
    private bool alreadyAttacked;
    public float damgeOfEnemy;
    public float damageTimer;
    private float timer = 0;


    //States
    public float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange;


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Überprüft die sicht und combat Range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
       // if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void FixedUpdate()
    {
        
        timer ++;

        if(timer >= timeBetweenAttacks )
        {
            timer = 0;
        }
        if (playerInSightRange && playerInAttackRange && timer == 1) AttackPlayer();



    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkpoint);

        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        //Wenn der Wegpunkt erreicht ist
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;               //Damit ein neuer Wegpunkt gesetzt wird
    }

    private void SearchWalkPoint()
    {
        //Random bewegpunkt
        float randomZ = Random.Range(-walkpointRange, walkpointRange);
        float randomX = Random.Range(-walkpointRange, walkpointRange);

        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkpoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);  //Der Enemy läuft dem Spieler hinterher
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);   //Schaut das der Gegner sich nicht bewegt
        transform.LookAt(player);                   //Der Enemy soll den Spieler anschauen

        Debug.Log(Vector3.Distance(agent.transform.position, player.position));
        if(Vector3.Distance(agent.transform.position , player.position) <= 20 )
        {
            Debug.Log("DISTANCE OK");

          //  if(timer == 1)
          //  {

                GiveDamage();
                
          //  }
            
        }
    }



    public void TakeDamage(int damage)
    {        
        //Der Gegner bekommt schaden
        gameObject.GetComponent<NPCStats>().SufferDamage(damage, playerStats); 
    }




    //Der Enemy gibt dem Spieler Schaden
  // private void OnTriggerEnter(Collider other)
  // {
  //     Debug.Log("COLLIDES");
  //     //Debug.Log("ONTRIGGER");
  //     if (other.gameObject.transform == player)
  //     {
  //         Debug.Log("COLLIDES WITH PLAYER");
  //         if (timer == 0)
  //         {
  //             GiveDamage();   //Gibt dem Spieler schaden
  //             Debug.Log("GIVEDAMAGE");
  //         }
  //     }          
  // }

    public void GiveDamage()
    {
        GameObject.Find("Player").GetComponent<Stats>().currentHitpoints -= damgeOfEnemy;   //schaut wie viel Leben der Spieler gerade hat
    }
}

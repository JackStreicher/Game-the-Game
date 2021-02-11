using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMove : MonoBehaviour
{
    public float speedOfTheFB;
    public float speedOfFireMode;
    public GameObject firepoint;
    public int fireBallDamage;
    private GameObject enemy;

    private Stats playerStats;


    public void Start()
    {
        Debug.Log(transform.rotation);
        transform.rotation = Quaternion.LookRotation(firepoint.transform.forward);

    }
    void Update()
    {
        //wenn speed nicht null ist dann ...
        if (speedOfTheFB != 0)
        {
            //... wird der Fireball in Bewegung gesetzt (die Geschwindigkeit wird multipliziert)
            transform.position += transform.forward * (speedOfTheFB * Time.deltaTime);
        }
        else
        {
            //Um einen Fehler zu vermeiden
            Debug.Log("The FireBall needs a amount of speed!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {


        speedOfTheFB = 0;               //wenn die Collision passiert ist, dann fliegt der Feuerball nicht mehr bzw steht und ...        
        Destroy(gameObject);            //... wird dann schließlich zerstört


        if(collision.transform.tag == "SecretPathway")
        {
            if (!GameObject.Find("HeilungsArtefakt"))
            {
                Destroy(collision.gameObject); // Zerstört den Stein der den Weg zum letzten Artefakt versperrt
            }
        }

        if (collision.transform.tag == "Enemy")
        {
            Debug.Log("collision mit enemy");
            collision.gameObject.GetComponent<NPCStats>().SufferDamage(fireBallDamage, playerStats);                      
        }
    }
}

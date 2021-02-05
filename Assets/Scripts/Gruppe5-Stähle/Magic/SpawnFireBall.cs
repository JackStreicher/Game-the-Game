using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireBall : MonoBehaviour
{
    public GameObject firePoint;                                            //Feuerpunkt wo die Feuerkugel entsteht
    public GameObject player;                                               //Um zu schauen wo der Spieler ist um in die Richtige Richtung zu schießen
    public List<GameObject> fireBallsList = new List<GameObject>();         //Liste von den Feuerbällen                        

    private GameObject effectToSpawn;                                       //Feuerball (wird im start mitgegeben)                         
    private float timeToFire = 0;                                           //Steuert wie oft der spieler schießen kann          
    public GameObject cam;                                                  //Um rotation zu verwenden

    void Start()
    {
        effectToSpawn = fireBallsList[0];
    }

    void Update()
    {
        //Wenn der Spieler Q drückt und der Timer größer ist als amount von timeToFire dann kann der Spieler einen Feuerball schießen
        if (Input.GetKeyDown(KeyCode.Q) && Time.time >= timeToFire) 
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<FireBallMove>().speedOfFireMode;
            SpawnFireBalls();
        }
    }

    void SpawnFireBalls()
    {
        GameObject fireballs;

        if (firePoint != null)  
        {
            //Instanziieren
            fireballs = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            fireballs.GetComponent<FireBallMove>().firepoint = firePoint;
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
}

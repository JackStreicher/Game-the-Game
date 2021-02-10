using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireBall : MonoBehaviour
{
    public GameObject firePoint;                                            //Feuerpunkt wo die Feuerkugel entsteht
    public List<GameObject> fireBallsList = new List<GameObject>();         //Liste von den Feuerbällen            
    public Mana mana;                                                       //Um mana einzubindne

    private GameObject effectToSpawn;                                       //Feuerball (wird im start mitgegeben)                         
    private float timeToFire = 0;                                           //Steuert wie oft der spieler schießen kann          
    public GameObject cam;                                                  //Um rotation zu verwenden
    public int manaPointsCost = 5;                                          //Manakosten

    void Start()
    {
        effectToSpawn = fireBallsList[0];
    }

    void Update()
    {
        //Wenn der Spieler Q drückt und der Timer größer ist als amount von timeToFire dann kann der Spieler einen Feuerball schießen und es muss Genügend Mana vorhanden sein und das Artefackt musste aufgenommen werden
        if (Input.GetKeyDown(KeyCode.Q) && Time.time >= timeToFire && mana.CanThePlayerUseMane(manaPointsCost) && !GameObject.Find("FeuerArtefakt")) 
        {
            mana.currentMana -= manaPointsCost; //Kosten abziehen
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

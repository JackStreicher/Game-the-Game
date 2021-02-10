using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealUP : MonoBehaviour
{
    public GameObject player;                                       //Um Position des spielers zu ermitteln
    public List<GameObject> healingList = new List<GameObject>();   //Liste 
    private GameObject healing;
    private GameObject destroyIt;
    public Slider HealthBar;                                        //Lebensbalken
    public Mana mana;                                               //mana einbinden

    //Variables
    public float healthGettingValue = 25;                           //Wie viel Leben der Spieler insgesamt dazu bekommt
    public float healtGettingValuePerTic = 1;                       //Wie viel Leben der Spieler pro Sekunde bekommt
    public float healthTime = 5f;                                   //Wie schnell der Spieler sich heilen möchte
    private float maxHealth;                                        //Maximale Leben das ein Spieler hat

    private float healthNow;                                        //Wie viel Leben der Spieler gerade hat
    public float timeToHealCooldown = 5;                            //Cooldown 
    private bool isHealingActive = false;                           //Boolean um Healing zu handeln  
    public int manaPointsCost = 30;                                 //Kosten Mana

    GameObject healingPrefab;

    private void Start()
    {        
        healing = healingList[0];
        healingPrefab = healing;
        maxHealth = player.GetComponent<Stats>().baseHitpoints;
        healthNow = player.GetComponent<Stats>().currentHitpoints;
        HealthBar.value = healthNow;
    }


    private void Update()
    {
        infoLife();
        
        //Wenn die Heilung nicht aktiviert wurde...
        if (!isHealingActive)
        {
            //... kann man zum Heilen E drücken, aber nur so lange man Mana hat und man muss das artefackt aufgenommen haben
            if (Input.GetKeyDown(KeyCode.E) && mana.CanThePlayerUseMane(manaPointsCost) && !GameObject.Find("HeilungsArtefakt"))
            {
                mana.currentMana -= manaPointsCost; //Kosten abziehen
                HealingUP();               
            }
        }
        else //Oder wenn man die Heilung aktiviert hat kann man sich nicht im gleichen moment heilen
        {                     
            postionOfHealingAnimation();    //Aktualisiert welche Positon die Animation stattfinden soll
        }
    }


    private void HealingUP()
    {
        isHealingActive = true;                                                             //boolean auf true setzen da der Spieler sich anfängt zu heilen


        healing = Instantiate(healingPrefab, player.transform.position, Quaternion.identity);     //Heilungsanimation


        StartCoroutine(HealingCourtine());                                                  //Spielerleben wird hinzugefügt                                              
    }

    private void infoLife()
    {
        //Aktuallisiert wie viel Leben der Spieler hat
        healthNow = player.GetComponent<Stats>().currentHitpoints;

        //Lebensbalken Updaten
        HealthBar.value = healthNow;
    }

    private void postionOfHealingAnimation()
    {
        //Wenn es gerade das Object gibt soll die  AKTUELLE Position des Spielers genommen werden
        if (healing != null)
        {
            healing.transform.position = new Vector3(player.transform.position.x, this.gameObject.transform.position.y, player.transform.position.z);
        }
    }


    IEnumerator HealingCourtine()
    {
        bool finished = false;

        //For schleife ---> geht nach jedem heilungs effect  
        for (int i = 0; i <= healthGettingValue; i++)
        {
            infoLife();                                             //Um das Leben zu aktuallisieren

            if (maxHealth > (healthNow + healtGettingValuePerTic))  //Wenn healtnow + healthGettingValuePerTic das Limit erreicht dann wird nicht mehr geheilt oder wenn die healtGettingValue komplett durchgeloffen ist
            {
                yield return new WaitForSeconds(healthTime/healthGettingValue);                                  //Gewísse Zeit abwarten wenn er geheilt wird
                player.GetComponent<Stats>().Heal(healtGettingValuePerTic);             //Der Spieler bekommt Leben dazu                                                        
            }
        }

        finished = true;
        yield return new WaitUntil(() => finished == true);   //Sobald es true ist geht es weiter


        destroyIt = GameObject.FindGameObjectWithTag("Healing");

        //Die Heilanimation muss verschwinden
        if (destroyIt != null)
        {
            Destroy(destroyIt);
            yield return new WaitForSeconds(1.5f);     //künstlichen Delay
            finished = false;               //Wird auf false zurückgesetzt    
            isHealingActive = false;        //Wird auf false zurückgesetzt  
        }
        
        

  
    }
}

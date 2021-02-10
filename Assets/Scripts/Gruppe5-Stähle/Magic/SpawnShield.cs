﻿using System.Collections;
using UnityEngine;

public class SpawnShield : MonoBehaviour
{

    public GameObject shield;               //Schild
    public Mana mana;                       //mana einbinden
    public float timeOfShield = 5f;         //Wie lange das Schild anhält
    private bool isShieldActivated = false;
    public int manaPointsCost = 25;        //Wie viel Manpunkte das Schild kostet

    //audio 
    public AudioClip soundShield;
    private AudioSource AudioManager;
    public float volumeValue = 0.1f;        //Um die Lautstärke zu regeln



    private void Start()
    {
        shield.gameObject.SetActive(false);   //schild animaiton wird von Anfang an deaktiviert um Probleme zu vermeiden

        //Audio
        AudioManager = GetComponent<AudioSource>();
        AudioManager.volume = volumeValue;      //CLautstärke regeln
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && !isShieldActivated && mana.CanThePlayerUseMane(manaPointsCost) && !GameObject.Find("ArtefaktSchild"))
        {
            shield.gameObject.SetActive(true);      //Schild animation wird aktiviert  
            AudioManager.PlayOneShot(soundShield);  //Audio wird gespielt
            isShieldActivated = true;               //Da schild Aktiviert ist wird es auf true gesetzt
            mana.currentMana -= manaPointsCost;     //Kosten abziehen                       
            StartCoroutine(ShielActivate());        //Courtine 
        }
    }


    IEnumerator ShielActivate()
    {        
        yield return new WaitForSeconds(timeOfShield);  //Zeit läuft von dem aktivierten schild ab
        shield.gameObject.SetActive(false);             //Schild animaiton wird deaktiviert

        yield return new WaitForSeconds(0.5f);          //Delay Zeit abklingen
        isShieldActivated = false;                      //Boolean wieder auf False setzten da das Schild deaktiviert ist
    }
}

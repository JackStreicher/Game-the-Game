using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHealingSound : MonoBehaviour
{

    public AudioClip soundHealing;
    private AudioSource AudioManager;       
    public float volumeValue = 0.1f;        //Um die Lautstärke zu regeln
    private int onlyOnce = 0;               //Damit nur einmalig der Sound kommt

    private void Start()
    {
        AudioManager = GetComponent<AudioSource>();

        AudioManager.volume = volumeValue;      //CLautstärke regeln
    }

    private void OnTriggerEnter(Collider other)
    {
        //Wenn das Gamobject mit dem Tag Player und es noch nie passiert ist die collison, dann wird ein Sound gespielt
        if (other.tag == "Player" && onlyOnce == 0)
        {
            AudioManager.PlayOneShot(soundHealing);         
        }
        ++onlyOnce;
    }

}

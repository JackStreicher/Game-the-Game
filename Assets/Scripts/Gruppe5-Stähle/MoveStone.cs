using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveStone : MonoBehaviour
{
    public Transform player;
    public Questlog ql;
    private Vector3 thresholdPosition;
    private Vector3 normalPosition;
    private bool doorOpening;
    private bool questRunning;

    void Start()
    {
        thresholdPosition = transform.position + new Vector3(0, 10, 0);
        normalPosition = transform.position;
    }

    void Update()
    {
        for (int i = 0; i < ql.GetQuestList().Count; i++)
        {
            if(ql.GetQuestList()[i].title == "Collect Artefacts") //Durchsucht die Questliste nach einer Quest mit dem bestimmten Titel
            {
                questRunning = true;
                break;
            }
        }
        if (this.transform.position.y <= thresholdPosition.y) //Wenn die jetztige y-Position kleiner oder gleich der Threshold-y-Position ist
        {
            if(this.tag == "Stone" && Vector3.Distance(normalPosition, player.position) < 13 && questRunning) //Wenn der Tag von dem Object auf dem das Script liegt Stone ist und die Distanz zwischen dem object und dem Spieler kleiner als 13 ist und die Quest in der Questliste gefunden werden konnte
            {
                if (Input.GetKey(KeyCode.P))
                {
                    transform.position += Vector3.up * Time.deltaTime; //Bewegt den Stein nach oben solange man P hält
                }
            }
            else if(this.tag == "PyramidDoor" && Vector3.Distance(normalPosition, player.position) < 3 && !doorOpening && !GameObject.Find("FeuerArtefakt"))//Wenn der Tag von dem Object auf dem das Script liegt PyramidDoor ist, die Tür noch nicht am öffnen ist, die Distanz zwischen dem object und dem Spieler kleiner als 3 ist und das Feuerartefakt nicht mehr in der Szene gefunden werden konnte
            {
                if (Input.GetKey(KeyCode.P))
                {
                    doorOpening = true;// setzt den Tür-Öffnungs-Vorgang in Lauf
                }
            }
        }
        if (doorOpening && this.transform.position.y <= thresholdPosition.y)
        {
            transform.position += (Vector3.up / 2) * Time.deltaTime;
        }
    }
}

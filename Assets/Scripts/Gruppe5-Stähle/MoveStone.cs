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
            if(ql.GetQuestList()[i].title == "Collect Artefacts")
            {
                questRunning = true;
                break;
            }
        }
        if (this.transform.position.y <= thresholdPosition.y)
        {
            if(this.tag == "Stone" && Vector3.Distance(normalPosition, player.position) < 13 && questRunning)
            {
                if (Input.GetKey(KeyCode.P))
                {
                    transform.position += Vector3.up * Time.deltaTime;
                }
            }
            else if(this.tag == "PyramidDoor" && Vector3.Distance(normalPosition, player.position) < 3 && !doorOpening && !GameObject.Find("FeuerArtefakt"))
            {
                if (Input.GetKey(KeyCode.P))
                {
                    doorOpening = true;
                }
            }
        }
        if (doorOpening && this.transform.position.y <= thresholdPosition.y)
        {
            transform.position += (Vector3.up / 2) * Time.deltaTime;
        }
    }
}

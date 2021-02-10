using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPaper : NPCConversation //erbt von NPCConversation
{
    public GameObject player;
    void Update()
    {
        //Debug.Log(player.GetComponent<PlayerInteraction>().target);
        //if(player.GetComponent<PlayerInteraction>().target == this)
        //{
        //    Debug.Log("target aquired");
        //}
        //if (player.GetComponent<PlayerInteraction>().target.gameObject == this && Input.GetKey(KeyCode.R))
        //{
        //    dialogManager.StartDialog(diag);
        //}

        if (Vector3.Distance(this.transform.position, player.transform.position) < 2)
        {
            if (Input.GetKey(KeyCode.R))
            {
                dialogManager.StartDialog(diag); // Wenn der Spieler nah genug an dem Blatt Papier ist und R drückt öffnet wird der Dialog gestartet
            }
        }
    }
}

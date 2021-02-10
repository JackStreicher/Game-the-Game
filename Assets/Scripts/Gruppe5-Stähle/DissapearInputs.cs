using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DissapearInputs : MonoBehaviour
{
    public GameObject leftPanel;

    void Update() // Zeigt den Text an oder nicht an, je nachdem ob der Questlog angezeigt wird
    {
        if (leftPanel.activeSelf)
        {
            this.gameObject.GetComponent<Text>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<Text>().enabled = true;
        }
    }
}

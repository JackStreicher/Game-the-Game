using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DissapearInputs : MonoBehaviour
{
    public GameObject leftPanel;
    public GameObject inputs;

    void Update() // Zeigt den Text an oder nicht an, je nachdem ob der Questlog angezeigt wird
    {
        if (leftPanel.activeSelf)
        {
            this.gameObject.GetComponent<Text>().enabled = false;
        }
        else
        {
            if ((this.gameObject.name == "FireballInput" && !GameObject.Find("FeuerArtefakt")) || 
                (this.gameObject.name == "ShieldInput" && !GameObject.Find("ArtefaktSchild")) ||
                (this.gameObject.name == "HealInput" && !GameObject.Find("HeilungsArtefakt")))
            {
                this.gameObject.GetComponent<Text>().enabled = true;
            }
            else if(this.gameObject.name != "FireballInput" && this.gameObject.name != "ShieldInput" && this.gameObject.name != "HealInput")
            {
                this.gameObject.GetComponent<Text>().enabled = true;
            }

        }

    }
}

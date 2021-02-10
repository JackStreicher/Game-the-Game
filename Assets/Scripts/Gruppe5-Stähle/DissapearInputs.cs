using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DissapearInputs : MonoBehaviour
{
    public GameObject leftPanel;

    void Update()
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseState : MonoBehaviour
{
    GameObject ui;
    public List<GameObject> uiPanels;
    bool isUIActive;
    bool lastState;
    int isAcitveCounter = 0;

    public LookMouse mouseRotation;

    private void Start()
    {
        ui = this.transform.gameObject;
        lastState = isUIActive;
    }

    public void LateUpdate()
    {
        isAcitveCounter = 0;

        foreach (GameObject panel in uiPanels)
        {

            if (panel.activeSelf)
            {
                isAcitveCounter++;
            }

        }

        if (isAcitveCounter > 0)
        {
            isUIActive = true;
            mouseRotation.isActive = false;
        }
        else if (isAcitveCounter == 0)
        {

            isUIActive = false;
            mouseRotation.isActive = true;
        }

        if (lastState != isUIActive)
        {

            if (isUIActive)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            lastState = isUIActive;
        }


    }
}

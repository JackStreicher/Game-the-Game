using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouse : MonoBehaviour
{

    public float mouseSensivity = 100f;
    public GameObject player;
    public GameObject rotationXTarget;

    public bool isActive;

    private float rotationX = 0f;

    public void Start()
    {
        isActive = true;
        try
        {
            //Gets the Parent GameObject
            //rotationXTarget = transform.parent.gameObject;
            //player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
            {
                throw new ArgumentNullException(); //wirft einen Fehler          
            }
           
            
        }
        catch //fängt den Fehler und führt den Code in der Klammer aus, statt den Fehler zu werfen
        {
            Debug.LogError("The Scrip 'LookMouse' needs a parent which it will rotate based on the mouse Axis." +
                "\nOr there is no GameObject with the tag 'Player' in your scene");
        }

        //Cursor invisible and locked to the center of the Screen
        Cursor.lockState = CursorLockMode.Locked;

    }


    public void Update()
    {
        if (isActive)
        {
            //getting the mouse axis
            float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;

            float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

            //we want to rotate the X Axis by moving the mouse up and down, that's why we put mouseY into rotationX
            rotationX -= mouseY;

            rotationX = Mathf.Clamp(rotationX, -80f, 80f); //min an max rotation angle

            //ration of the X-Axis
            rotationXTarget.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f); //rotate only X and not y and z

            //rotate the players y (up) axis
            player.transform.Rotate(Vector3.up * mouseX);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject crossHair;
    public GameObject target;
    

    private Text targetName;

    public Camera cam;
    public Camera camThirdPerson;
    public Camera camFirstPerson;

    public InventoryManager inventory;
    private InventoryUIConnection inventoryUI;

    //Add in inspector
    public Questlog questlog;

    [HideInInspector]
    public SimpleInventoryList questItemInventory;

    public void Start()
    {

        targetName = GameObject.Find("TargetName").GetComponent<Text>();
        inventoryUI = GameObject.Find("Inventory").GetComponent<InventoryUIConnection>();
        questItemInventory = GameObject.Find("Inventory").GetComponent<SimpleInventoryList>();
    }

    public void SetTarget()
    {
        //Creates a Ray at the Crosshairposition (Ray from camera through the crisshair)
        Ray worldPosCrosshair = cam.ScreenPointToRay(crossHair.transform.position);

        RaycastHit hit;

        if (Physics.Raycast(worldPosCrosshair, out hit, 20f) && hit.transform.tag != "Terrain")
        {
            targetName.text = hit.transform.name;
            target = hit.transform.gameObject;
            //Add Item Logic
            if (hit.transform.tag == "Interactable" && Input.GetKey(KeyCode.F))
            {
                //9 == QuestITem
                if (hit.transform.gameObject.layer == 9)
                {
                    
                    questItemInventory.items.Add(hit.transform.GetComponent<ItemStats>().itemStats);
                    Remover.CheckAndRemove(hit.transform.gameObject);
                }
                else if (inventory.AddItem(hit.transform.GetComponent<ItemStats>().itemStats, 1))  //Add Item to Inventory
                {
                    //Update Visual Inventory
                    inventoryUI.UpdateInventoryUI();

                    //Check if the GameObject was relevant to a quest and remove it
                    Remover.CheckAndRemove(hit.transform.gameObject);

                   

                }
                

            }
            //Kill test
            //if (hit.transform.tag == "Enemy" && hit.transform.GetComponent<NPCStats>() != null && Input.GetKey(KeyCode.F))
            //{
            //    hit.transform.GetComponent<NPCStats>().SufferDamage(99999999, transform.GetComponent<Stats>());
            //}
        }
        else
        {
            targetName.text = "";
        }


    }


    public void Update()
    {
        SetTarget();
    }
}

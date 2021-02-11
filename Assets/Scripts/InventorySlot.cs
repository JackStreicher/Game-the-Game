using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{   
    public int number;

    public EquipmentManager equipmentManager;
    public InventoryManager inventory;  //needed for the Item at the itemarray position

    //public InventoryManager
    public void Start()
    {
        //equipmentManager = GameObject.Find("Equipment").GetComponent<EquipmentManager>(); //needed for adding ITems to the slots of the UI and the PLayer GO
        //inventory = GameObject.Find("Inventory").GetComponent<InventoryUIConnection>().inventory; //needed for adding ITems to the slots of the UI and the PLayer GO
          
    }


    public virtual void Interact()
    {
        
            equipmentManager.InteractWithInventoryUI(inventory.inventoryItems[number]);
        
            Debug.LogWarning("The ItemSlot in the inventory you are trying to access seems to be null");
        
    }

}

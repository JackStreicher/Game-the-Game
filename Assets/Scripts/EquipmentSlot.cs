using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{

    public enum Slot
    {

        Head,
        Horns,
        Neck,
        ShoulderL,
        ShoulderR,
        UpperArmL,
        UpperArmR,
        LowerArmL,
        LowerArmR,
        HandL,
        HandR,
        WeaponL,
        WeaponR,
        Torso,
        UpperStomach,
        Belt,
        Groin,
        UpperLegL,
        UpperLegR,
        ShinL,
        ShinR,
        AnkleL,
        AnkleR,
        Backpack,
        Staff,
        Bow,
        Shield,
        None
    }


    public Slot slot;
    Item equipped { get; set; }
    public bool hasMirror;
    public bool isEmpty { get; private set; } = true;    
    private InventoryManager inventory;
    private InventoryUIConnection inventoryUI;
    private GameObject equipmentPanel;


    public void Start()
    {
        inventoryUI = GameObject.Find("Inventory").GetComponent<InventoryUIConnection>();
        inventory = GameObject.Find("Inventory").GetComponent<InventoryUIConnection>().inventory;
        equipmentPanel = GameObject.Find("CharacterEquipmentPanel");
    }

    public bool Equip(Item newItem)
    {

        if (newItem != null && newItem.equipmentSlot.ToString() == slot.ToString())
        {

            var previousItem = equipped;
            equipped = newItem;
            if (previousItem != null)
            {
                if (inventory.AddItem(previousItem, 1))
                {
                    previousItem.RemoveStats();  //remove the stats of the old item
                                             //sets the new item
                    UpdateUIAndApplyStats(equipped);
                    inventory.RemoveItem(equipped, 1);
                    inventoryUI.UpdateInventoryUI();
                    return true;
                }
                else
                {
                    Debug.LogWarning("You must make room in your inventory before you can equip this item");
                    return false;
                }
               
            }

            else 
            {
                
                UpdateUIAndApplyStats(equipped);
                inventory.RemoveItem(equipped, 1);
                inventoryUI.UpdateInventoryUI();
                return true;
            }
           


        }
        else
        {
            return false;
        }

    }

    private void UpdateUIAndApplyStats(Item item)
    {
        Armor armor = null;
        Weapon weapon = null;


        if (item is Armor)
        {
            armor = (Armor)item;
            weapon = null;
        }
        if (item is Weapon)
        {
            weapon = (Weapon)item;
            armor = null;
        }

        if(weapon == null)
        {
            UpdateEquipmentUI(armor, slot.ToString()); //update the UI
                                                          //Add Item Mesh to the right position -> this.transform

            armor.ApplyStats();
        }
        if (armor == null)
        {
            UpdateEquipmentUI(weapon, slot.ToString()); //update the UI
                                                       //Add Item Mesh to the right position -> this.transform
  
            weapon.ApplyStats();
        }

    }

    public bool Unequip()
    {

        if (equipped != null)
        {
            if (inventory.AddItem(equipped, 1))
            {
                equipped.RemoveStats();
                UpdateEquipmentUI(slot.ToString()); //remove UI image
                inventoryUI.UpdateInventoryUI();
                equipped = null;
                return true;
            }
            else
            {
                Debug.Log("You must make space in your inventory.");
                return false;
            }

        }
        else
        {
            Debug.Log("You can't unequip an item that is not equiped");
            return false;
        }

    }


    public void UpdateEquipmentUI(Item newItem, string slotName)
    {
        Button itemUISlot = equipmentPanel.transform.Find(slotName).GetComponent<Button>();
        if (newItem.GetItemImage() != null)
            itemUISlot.image.sprite = newItem.GetItemImage();
        else
            Debug.LogWarning(newItem.name + " requires an image sprite");
    }

    public void UpdateEquipmentUI(string slotName)
    {
        Button itemUISlot = equipmentPanel.transform.Find(slotName).GetComponent<Button>();

        itemUISlot.image.sprite = null;
    }
}

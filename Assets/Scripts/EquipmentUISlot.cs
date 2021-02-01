using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUISlot : InventorySlot
{

    private string itemSlotName;

    

    public  override void Interact()
    {
        number = 0;
        itemSlotName = this.transform.gameObject.name;

        for(int i = 0; i < equipmentManager.equipmentSlotArray.Length; i++)
        {
            if (equipmentManager.equipmentSlotArray[i] != null && equipmentManager.equipmentSlotArray[i].slot.ToString() == itemSlotName)
            {
                equipmentManager.equipmentSlotArray[i].Unequip();
            }
        }
       
    }
}

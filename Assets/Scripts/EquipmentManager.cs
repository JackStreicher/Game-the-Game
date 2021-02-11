using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    public Transform player;

    public EquipmentSlot helmet { get; set; }
    public EquipmentSlot horns { get; set; }
    public EquipmentSlot neck { get; set; }
    public EquipmentSlot shoulderL { get; set; }
    public EquipmentSlot shoulderR { get; set; }
    public EquipmentSlot torso { get; set; }
    public EquipmentSlot upperArmL { get; set; }
    public EquipmentSlot upperArmR { get; set; }
    public EquipmentSlot lowerArmL { get; set; }
    public EquipmentSlot lowerArmR { get; set; }
    public EquipmentSlot handL { get; set; }
    public EquipmentSlot handR { get; set; }
    public EquipmentSlot upperStomach { get; set; }
    public EquipmentSlot belt { get; set; }
    public EquipmentSlot groin { get; set; }
    public EquipmentSlot upperLegL { get; set; }
    public EquipmentSlot upperLegR { get; set; }
    public EquipmentSlot shinR { get; set; }
    public EquipmentSlot shinL { get; set; }
    public EquipmentSlot backpack { get; set; }
    public EquipmentSlot weaponL { get; set; }
    public EquipmentSlot weaponR { get; set; }
    public EquipmentSlot bowStowed { get; set; }
    public EquipmentSlot shieldStowed { get; set; }
    public EquipmentSlot staffStowed { get; set; }

    public Transform weaponStowedL { get; set; }

    public EquipmentSlot[] equipmentSlotArray = new EquipmentSlot[24];

    InventoryManager inventory;
    InventoryUIConnection inventoryUIConnection;
    public GameObject equipmentPanel;
    public Sprite defaultSprite;


    public void Awake()
    {
        inventoryUIConnection = GameObject.Find("Inventory").GetComponent<InventoryUIConnection>();
        inventory = inventoryUIConnection.inventory;
        
        //Getting all the Item EquipmentSlot Scripts
        helmet = GameObject.Find("HeadArmorSlot").GetComponent<EquipmentSlot>();
        horns = GameObject.Find("HornsArmorSlot").GetComponent<EquipmentSlot>();
        neck = GameObject.Find("NeckArmorSlot").GetComponent<EquipmentSlot>();
        shoulderL = GameObject.Find("ShoulderArmorSlotLeft").GetComponent<EquipmentSlot>();
        shoulderR = GameObject.Find("ShoulderArmorSlotRight").GetComponent<EquipmentSlot>();
        torso = GameObject.Find("TorsoArmorSlot").GetComponent<EquipmentSlot>();
        upperArmL = GameObject.Find("UpperArmArmorSlotLeft").GetComponent<EquipmentSlot>();
        upperArmR = GameObject.Find("UpperArmArmorSlotRight").GetComponent<EquipmentSlot>();
        lowerArmL = GameObject.Find("LowerArmArmorSlotLeft").GetComponent<EquipmentSlot>();
        lowerArmR = GameObject.Find("LowerArmArmorSlotRight").GetComponent<EquipmentSlot>();
        handL = GameObject.Find("HandArmorSlotLeft").GetComponent<EquipmentSlot>();
        handR = GameObject.Find("HandArmorSlotRight").GetComponent<EquipmentSlot>();
        upperStomach = GameObject.Find("UpperStomachArmorSlot").GetComponent<EquipmentSlot>();
        belt = GameObject.Find("HipArmorSlot").GetComponent<EquipmentSlot>();
        groin = GameObject.Find("GroinArmorSlot").GetComponent<EquipmentSlot>();
        upperLegL = GameObject.Find("UpperLegArmorSlotLeft").GetComponent<EquipmentSlot>();
        upperLegR = GameObject.Find("UpperLegArmorSlotRight").GetComponent<EquipmentSlot>();
        shinR = GameObject.Find("ShinArmorSlotRight").GetComponent<EquipmentSlot>();
        shinL = GameObject.Find("ShinArmorSlotLeft").GetComponent<EquipmentSlot>();
        weaponL = GameObject.Find("WeaponHandLeft").GetComponent<EquipmentSlot>();
        weaponR = GameObject.Find("WeaponHandRight").GetComponent<EquipmentSlot>();

        shieldStowed = GameObject.Find("ShieldStowedSlot").GetComponent<EquipmentSlot>();
        staffStowed = GameObject.Find("StaffStowedSlot").GetComponent<EquipmentSlot>();
        bowStowed = GameObject.Find("BowStowedSlot").GetComponent<EquipmentSlot>();
        weaponStowedL = GameObject.Find("WeaponSheathSlotLeft").GetComponent<Transform>();

        equipmentSlotArray[0] = helmet;
        equipmentSlotArray[1] = horns;
        equipmentSlotArray[2] = neck;
        equipmentSlotArray[3] = shoulderL;
        equipmentSlotArray[4] = shoulderR;
        equipmentSlotArray[5] = torso;
        equipmentSlotArray[6] = upperArmL;
        equipmentSlotArray[7] = upperArmR;
        equipmentSlotArray[8] = lowerArmL;
        equipmentSlotArray[9] = lowerArmR;
        equipmentSlotArray[10] = handL;
        equipmentSlotArray[11] = handR;
        equipmentSlotArray[12] = upperStomach;
        equipmentSlotArray[13] = belt;
        equipmentSlotArray[14] = groin;
        equipmentSlotArray[15] = upperLegL;
        equipmentSlotArray[16] = upperLegR;
        equipmentSlotArray[17] = shinR;
        equipmentSlotArray[18] = shinL;
        equipmentSlotArray[19] = weaponL;
        equipmentSlotArray[20] = weaponR;
        equipmentSlotArray[21] = shieldStowed;
        equipmentSlotArray[22] = staffStowed;
        equipmentSlotArray[23] = bowStowed;




    }
    ///<summary>This Method should be called by the Inventory Buttons</summary>
    public void InteractWithInventoryUI(Item invItem)
    {

        
        if (invItem != null)
        {


            if (invItem is Consumable)
            {
                Consumable consItem = (Consumable)invItem;

                Debug.Log("Item");

                consItem.Consume(null);
                inventory.RemoveItem(invItem ,1);
                inventoryUIConnection.UpdateInventoryUI();

                return;
            }
            if (invItem is Armor)
            {

                for (int i = 0; i < equipmentSlotArray.Length; i++)
                {
                    if (equipmentSlotArray[i] != null) {
                        if (equipmentSlotArray[i].slot.ToString() == invItem.equipmentSlot.ToString())
                        {
                            equipmentSlotArray[i].Equip((Armor)invItem);
                            return;
                        }
                    }
                    else
                    {
                        Debug.Log("equipmentSlotArray " + i + " is null" );
                        return;
                    }

                }

            }
            if (invItem is Weapon)
            {
                Debug.Log("Weapon");
                for (int i = 0; i < equipmentSlotArray.Length; i++)
                {
                    if (equipmentSlotArray[i] != null)
                    {
                        if (equipmentSlotArray[i].slot.ToString() == invItem.equipmentSlot.ToString())
                        {
                            equipmentSlotArray[i].Equip((Weapon)invItem);
                            return;
                        }
                    }
                    else
                    {
                        Debug.Log("equipmentSlotArray " + i + " is null");
                        return;
                    }

                }

            }
        }
    }







    /*
      ///<summary>This Method should be called by the Inventory Buttons</summary>
    public void InteractWithInventoryUI(Weapon invItem)
    {


        if (invItem != null)
        {




            for (int i = 0; i < equipmentSlotArray.Length; i++)
            {
                if (equipmentSlotArray[i] != null)
                {
                    if (equipmentSlotArray[i].slot.ToString() == invItem.equipmentSlot.ToString())
                    {
                        equipmentSlotArray[i].Equip(invItem);

                    }
                }
                else
                {
                    Debug.Log("equipmentSlotArray " + i + " is null");
                }

            }

        }
    }

    public void InteractWithInventoryUI(Armor invItem)
    {


        if (invItem != null)
        {




            for (int i = 0; i < equipmentSlotArray.Length; i++)
            {
                if (equipmentSlotArray[i] != null)
                {
                    if (equipmentSlotArray[i].slot.ToString() == invItem.equipmentSlot.ToString())
                    {
                        equipmentSlotArray[i].Equip(invItem);

                    }
                }
                else
                {
                    Debug.Log("equipmentSlotArray " + i + " is null");
                }

            }



        }
    }

    ///<summary>This Method should be called by the Inventory Buttons</summary>
    public void InteracWithInventoryUI(Consumable invItem)
    {
        if (invItem != null)
        {


            if (invItem is Consumable)
            {
                Consumable consItem = (Consumable)invItem;

                consItem.Consume(null);
            }

        }

    }
     */

    /*
    public void UpdateEquipmentUI(Item newItem, string slotName)
    {
        Button itemUISlot = equipmentPanel.transform.Find(slotName).GetComponent<Button>();
        if (newItem.GetItemImage() != null)
            itemUISlot.image.sprite = newItem.GetItemImage();
        else
            itemUISlot.image.sprite = defaultSprite;
    }
    */
    /*
        public void Equip(Item newItem)
        {
            Item tempItem;

            switch (newItem.equipmentSlot)
            {

                case Item.EquipmentSlot.Helmet:
                    if (helmet != null)
                    {
                        tempItem = helmet;
                        if (inventory.AddItem(tempItem, 1))
                        {
                            helmet = newItem;
                        }
                    }
                    else
                    {
                        Debug.LogWarning("You need more space in your inventory first if you wish to equip this item");
                    }
                    break;

                case Item.EquipmentSlot.Horns:
                    if (horns != null)
                    {
                        tempItem = horns;
                        if (inventory.AddItem(tempItem, 1))
                        {
                            horns = newItem;
                        }
                    }
                    else
                    {
                        Debug.LogWarning("You need more space in your inventory first if you wish to equip this item");
                    }
                    break;
                case Item.EquipmentSlot.Neck:
                    if (neck != null)
                    {
                        tempItem = neck;
                        if (inventory.AddItem(tempItem, 1))
                        {
                            neck = newItem;
                        }
                    }
                    else
                    {
                        Debug.LogWarning("You need more space in your inventory first if you wish to equip this item");
                    }
                    break;
                case Item.EquipmentSlot.Shoudler:
                    if (shoulder != null)
                    {
                        tempItem = shoulder;
                        if (inventory.AddItem(tempItem, 1))
                        {
                            shoulder = newItem;
                        }
                    }
                    else
                    {
                        Debug.LogWarning("You need more space in your inventory first if you wish to equip this item");
                    }
                    break;
                case Item.EquipmentSlot.UpperArm:
                    if (upperArm != null)
                    {
                        tempItem = upperArm;
                        if (inventory.AddItem(tempItem, 1))
                        {
                            upperArm = newItem;
                        }
                    }
                    else
                    {
                        Debug.LogWarning("You need more space in your inventory first if you wish to equip this item");
                    }
                    break;
                case Item.EquipmentSlot.LowerArm:
                    if (lowerArm != null)
                    {
                        tempItem = lowerArm;
                        if (inventory.AddItem(tempItem, 1))
                        {
                            lowerArm = newItem;
                        }
                    }
                    else
                    {
                        Debug.LogWarning("You need more space in your inventory first if you wish to equip this item");
                    }
                    break;
                case Item.EquipmentSlot.Hand:
                    if (hand != null)
                    {
                        tempItem = hand;
                        if (inventory.AddItem(tempItem, 1))
                        {
                            hand = newItem;
                        }
                    }
                    else
                    {
                        Debug.LogWarning("You need more space in your inventory first if you wish to equip this item");
                    }
                    break;
                case Item.EquipmentSlot.Belt:
                    if (belt != null)
                    {
                        tempItem = belt;
                        if (inventory.AddItem(tempItem, 1))
                        {
                            belt = newItem;
                        }
                    }
                    else
                    {
                        Debug.LogWarning("You need more space in your inventory first if you wish to equip this item");
                    }
                    break;
                case Item.EquipmentSlot.Groin:
                    if (groin != null)
                    {
                        tempItem = groin;
                        if (inventory.AddItem(tempItem, 1))
                        {
                            groin = newItem;
                        }
                    }
                    else
                    {
                        Debug.LogWarning("You need more space in your inventory first if you wish to equip this item");
                    }
                    break;
                case Item.EquipmentSlot.UpperLeg:
                    if (upperLeg != null)
                    {
                        tempItem = upperLeg;
                        if (inventory.AddItem(tempItem, 1))
                        {
                            upperLeg = newItem;
                        }
                    }
                    else
                    {
                        Debug.LogWarning("You need more space in your inventory first if you wish to equip this item");
                    }
                    break;
                case Item.EquipmentSlot.Shin:
                    if (shin != null)
                    {
                        tempItem = shin;
                        if (inventory.AddItem(tempItem, 1))
                        {
                            shin = newItem;
                        }
                    }
                    else
                    {
                        Debug.LogWarning("You need more space in your inventory first if you wish to equip this item");
                    }
                    break;
                case Item.EquipmentSlot.Backpack:
                    if (backpack != null)
                    {
                        tempItem = backpack;
                        if (inventory.AddItem(tempItem, 1))
                        {
                            backpack = newItem;
                        }
                    }
                    else
                    {
                        Debug.LogWarning("You need more space in your inventory first if you wish to equip this item");
                    }
                    break;


            }



        }

        */
}

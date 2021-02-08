using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryManager", menuName = "ScriptableObjects/InventoryManager", order = 1)]
public class InventoryManager : ScriptableObject
{

    /// <summary>
    /// Do not Edit
    /// </summary>    
    [SerializeField]
    public Item[] inventoryItems;

    /// <summary>
    /// Do not Edit
    /// </summary>  
    public int[] inventoryItemAmount;

    private void OnValidate()
    {
        inventoryItems = new Item[9];
        inventoryItemAmount = new int[9];
    }
    /// <summary>
    /// Add Itemasdasdasdasdasdasd
    /// </summary>
    /// <param name="newItem"></param>
    /// <param name="amount"></param>
    /// <returns> LALALALA </returns>
    public bool AddItem(Item newItem, int amount)
    {

        bool operationSuccessfull = false;
        int newItemStackLimit = newItem.GetMaximumStackSize();

        for (int i = 0; i < inventoryItems.Length; i++)
        {
            //If there is an empty slot
            if (inventoryItems[i] == null)
            {

                if (inventoryItemAmount[i] + amount <= newItemStackLimit)
                {
                    inventoryItems[i] = newItem;
                    inventoryItemAmount[i] += amount;
                    operationSuccessfull = true;
                    //Debug.Log("Added New Item");
                    break;
                }
                else
                {
                    operationSuccessfull = false;
                    //Debug.Log("Did not add Item");
                    break;
                }
                //end the Loop                

            }
            //If one such item is already inside the inventory
            if (inventoryItems[i].name == newItem.name)
            {
                //If the items exists and the stacksize will not be exceeded
                if (inventoryItemAmount[i] + amount <= newItemStackLimit)
                {
                    inventoryItemAmount[i] += amount;
                    operationSuccessfull = true;
                    //Debug.Log("Stacked Item");
                    break;
                }


            }


        }
        if (!operationSuccessfull)
        {
            //If the Inventory has been iterated and nothing could be added
            Debug.Log("Your Inventory is full");

        }
        return operationSuccessfull;
    }

    public bool RemoveItem(Item item, int amount)
    {
        bool operationSuccessfull = false;

        for (int i = 0; i < inventoryItems.Length; i++)
        {

            if(inventoryItems[i] != null) {
                if (inventoryItems[i].name == item.name && inventoryItemAmount[i] - amount >= 0)
                {

                    inventoryItemAmount[i] -= amount;
                  
                    if (inventoryItemAmount[i] <= 0)
                    {
                        inventoryItemAmount[i] = 0;

                        inventoryItems[i] = null;
                    }

                    operationSuccessfull = true;
                    break;
                }
                else
                {
                    operationSuccessfull = false;

                }
            }
        }

        return operationSuccessfull;
    }
    public bool RemoveItem(int position)
    {
        bool operationSuccessfull = false;
        if (inventoryItems[position] != null)
        {
            inventoryItemAmount[position] -= 1;

            //get the Playerposition from the playerStats instead of this variant used here
            var player = GameObject.Find("Player");
                                                               //Multiply the Player rotation with the offset Vector to rotate the offset towards the same direction as the
            var spawnPosition = player.transform.position + (player.transform.rotation * new Vector3(0, 3, 1.5f));
            //spawn it
            try
            {
                Instantiate(inventoryItems[position].GetItemPrefab(), spawnPosition, Quaternion.identity);
            }
            catch
            {
                Debug.LogError("You must add a Prefab-Reference to the ScriptableObject you are trying to spawn");
            }

            operationSuccessfull = true;

            if (inventoryItemAmount[position] <= 0)
            {
                inventoryItemAmount[position] = 0;    
                inventoryItems[position] = null;
            }
        }


        return operationSuccessfull;
    }
}

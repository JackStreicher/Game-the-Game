using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIConnection : MonoBehaviour
{

    public InventoryManager inventory;

    public Sprite defaultImage;

    public Button[] itemSlots = new Button[9];

    public void UpdateInventoryUI()
    {
        for (int i= 0; i < inventory.inventoryItems.Length; i++)
        {

            if (inventory.inventoryItems[i] == null)
            {
                itemSlots[i].image.sprite = defaultImage;

                itemSlots[i].transform.GetChild(0).GetComponent<Text>().text = "";

                //If the first child is not a Text it will look for the Child via a string (name search) .
                if (itemSlots[i].transform.GetChild(0).GetComponent<Text>() == null)
                {
                    itemSlots[i].transform.Find("Amount").GetComponent<Text>().text = "";
                }
              
                
            }
            else
            {

                itemSlots[i].image.sprite = inventory.inventoryItems[i].GetItemImage();

                itemSlots[i].transform.GetChild(0).GetComponent<Text>().text = inventory.inventoryItemAmount[i].ToString();

                
                if (itemSlots[i].transform.GetChild(0).GetComponent<Text>() == null)
                {
                    itemSlots[i].transform.Find("Amount").GetComponent<Text>().text = inventory.inventoryItemAmount[i].ToString();
                }

            }


        }



    }


    public void RemoveItem(int position)
    {
        inventory.RemoveItem(position);
        UpdateInventoryUI();

    }
}

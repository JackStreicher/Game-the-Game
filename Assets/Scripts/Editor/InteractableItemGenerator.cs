using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class InteractableItemGenerator : EditorWindow
{
  
    enum ItemType
    {
        consumable,
        armor,
        item
    }

    enum Tag
    {
        Interactable
    }

    GameObject model;
    Item itemScriptableObject;
    bool hasRigidBody = true;

    Tag tag = Tag.Interactable;
    ItemType itemType = ItemType.item;


    [MenuItem("Item Tools/Iteractable Item Generator")]
    public static void ShowWindow()
    {
        GetWindow(typeof(InteractableItemGenerator));
    }

    public void OnGUI()
    {
        //Header
        GUILayout.Label("Create an interactable Item", EditorStyles.boldLabel);

        //Fields and which fields is responsible for which variable
        model = (GameObject)EditorGUILayout.ObjectField("Model (not a prefab)", model, typeof(GameObject), false);
        tag = (Tag)EditorGUILayout.EnumPopup("Item Tag", tag);
        itemType = (ItemType)EditorGUILayout.EnumPopup("Type of item", itemType);
        hasRigidBody = EditorGUILayout.Toggle("Add a Rigidbody to the Prefab (if not existent)", hasRigidBody);
        


        switch (itemType)
        {

            case ItemType.armor:
                itemScriptableObject = (Armor)EditorGUILayout.ObjectField("Scriptable Object Instance (not the script)", itemScriptableObject, typeof(Armor), false);
                break;            

            case ItemType.consumable:
                itemScriptableObject = (Consumable)EditorGUILayout.ObjectField("Scriptable Object Instance (not the script)", itemScriptableObject, typeof(Consumable), false);
                break;

            case ItemType.item:
                itemScriptableObject = (Item)EditorGUILayout.ObjectField("Scriptable Object Instance (not the script)", itemScriptableObject, typeof(Item), false);
                break;

        }


        //All the logic that is supposed to happen once we click on "Create Item" - a button which comes into existence right below this line
        if(GUILayout.Button("Create Item"))
        {
            if (model != null && model.name != null && model.name != "")
            {
                //holds whatever itemType was chosen
                Item[] createScriptableObject = new Item[1];
                
                //we need to instnatiate the model first
                var instanciatedModel = Instantiate(model);

                #region Add Components the the instanciated Model

                //Add Collider
                if (instanciatedModel.GetComponent<Collider>() == null)
                {
                    var tempCollider = instanciatedModel.AddComponent<MeshCollider>();
                    tempCollider.convex = true;
                }

                //Add Rigidbody
                if (instanciatedModel.GetComponent<Rigidbody>() == null && hasRigidBody)
                {
                    instanciatedModel.AddComponent<Rigidbody>();
                }

                //Add Tag
                instanciatedModel.tag = tag.ToString();

                //Add Item Stats script, which holds a reference to the Scriptable Object of the item
                var tempItemStats = instanciatedModel.AddComponent<ItemStats>();
                tempItemStats.itemStats = itemScriptableObject;

                //Set Name
                instanciatedModel.name = itemScriptableObject.GetName();

                //Setting Prefab location (path) and generating the Prefab
                string prefPath = "Assets/Prefabs/Items/" + instanciatedModel.name + ".prefab";
                GameObject newPrefab = PrefabUtility.SaveAsPrefabAsset(instanciatedModel, prefPath);

                //Set Prefab for the Scriptable Object
                itemScriptableObject.SetItemPrefab(newPrefab);

                //Clean-Up
                DestroyImmediate(instanciatedModel);

                //Exit
                this.Close();

                #endregion

            }


        }

    }



}

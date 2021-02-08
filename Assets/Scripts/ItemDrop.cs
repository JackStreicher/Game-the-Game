using UnityEngine;

public class ItemDrop : MonoBehaviour
{

   
    
    private Vector3 pos;
    private SimpleInventoryList npcInventory;
    // Start is called before the first frame update

    public void Start()
    {
       
        npcInventory = transform.GetComponent<SimpleInventoryList>();
        
    }
 

    public void DropItems()
    {
        pos = transform.position;

        if (npcInventory != null)
        {
            foreach (Item item in npcInventory.items)
            {
                GameObject itemToSpawn = item.GetItemPrefab();
                Vector3 offset = Vector3.up;
                var spawned = Instantiate(itemToSpawn, pos + offset, Quaternion.identity);

                //only for items with a rigidbody
                if (spawned.GetComponent<Rigidbody>() != null)
                {
                    //initiate force to accelaerate the object upwards

                    //change the Seed among Random generations to guarantee different values
                    Random.InitState(System.DateTime.Now.Millisecond);

                    int rand1 = Random.Range(-8, 8);                    
                    int rand2 = Random.Range(-8, 8);


                    spawned.GetComponent<Rigidbody>().velocity =
                                                    new Vector3(rand1, 15f, rand2);
                }
                
            }
        }
        else
        {
            Debug.Log("Rigidbody of the item is null");
        }
    }
}

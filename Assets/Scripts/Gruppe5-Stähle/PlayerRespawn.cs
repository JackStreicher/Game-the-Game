using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private float healthNow;            //aktuelles Leben des Spielers
    public GameObject respawnPoint;     //respawn punkt auf der Map 

    private void Start()
    {
        //Abfrage, damit man nicht vergisst den respawnpunkt einzutragen
        if(respawnPoint = null) 
        {
            Debug.Log("You need to select a Respawnpoint!");
        }
    }

    private void Update()
    {
        UpdateHealth(); //Spielerleben wird aktualisiert

        //Wenn das Leben des Spielers unter bzw = 0 ist dann wird er ...
        if(healthNow <= 0)
        {
            Respawn();  //... respawnt
        }
    }

    private void UpdateHealth()
    {
        healthNow = gameObject.GetComponent<Stats>().currentHitpoints;
    }

    private void Respawn()
    {
        //Der Spieler wird zum Respawnpoint geportet
        gameObject.transform.position = respawnPoint.transform.position;

        //Das Leben wird wieder zurückgesetzt
        healthNow = 50f;
    }

}

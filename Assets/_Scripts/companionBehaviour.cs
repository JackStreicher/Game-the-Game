using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class companionBehaviour : MonoBehaviour
{
    private GameObject player;
    public bool arrived;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        arrived = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(startBehaviour());
    }

    IEnumerator startBehaviour()
    {
        yield return new WaitForSeconds(2f);
        if(!arrived)
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .2f);
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            //look at player
            transform.LookAt(other.transform, Vector3.up);
            arrived = true;

            
        }
    }

}

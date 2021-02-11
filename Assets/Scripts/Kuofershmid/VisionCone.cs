using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour
{

    public MonsterAI mAI;

    public void Start()
    {
        mAI = transform.parent.GetComponent<MonsterAI>();
    }

    public void OnTriggerEnter(Collider col)
    {
        Debug.Log("Player Entered");
        if (col.transform.CompareTag("Player")) mAI.SetPlayerVisible(true);
    }

    public void OnTriggerExit(Collider col)
    {
        Debug.Log("Player Exited");
        if (col.transform.CompareTag("Player")) mAI.SetPlayerVisible(false);
    }
    
}

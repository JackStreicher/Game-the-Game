using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    [Header("Obj that must be pushed")]
    public GameObject pushOBJ;

    [Header("Time to wait for the next push")]
    public float waitForMove = 0.05f;

    [Header("Push")]
    public float push_LR;
    public float push_FB;
    public float psuhES;
    public string pushOBJTag;
    private bool isPushed;



    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
        if (isPushed == true)
        {
            StartCoroutine(Push());
        }
            
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == pushOBJTag)
        {
            isPushed = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == pushOBJTag)
        {
            isPushed = false;
        }
    }
    public IEnumerator Push()
    {
        
        yield return new WaitForSeconds(waitForMove);


 

        for(float i = 0; i <= psuhES;)
        {
            pushOBJ.transform.Translate(new Vector3(push_LR, 0, push_FB) * Time.deltaTime);
            i++;
        }
    }
}

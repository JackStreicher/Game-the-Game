using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Remover
{

    private static Questlog questlog = GameObject.Find("Questlog").GetComponent<Questlog>();


    public static void CheckAndRemove(GameObject obj)
    {
        Debug.Log("CheckAndRemove: "+obj.name);

        questlog.CheckAddProgress(obj);
        MonoBehaviour.Destroy(obj);
    }

    
    
   

    public static IEnumerator DelayAndRemove(GameObject obj, float delay)
    {
        questlog.CheckAddProgress(obj);
        //Sets the body to not interact with physics so we can't for example collect an apple twice (Due to the delay)
        obj.GetComponent<Rigidbody>().isKinematic = true;

        yield return new WaitForSeconds(delay);

        MonoBehaviour.Destroy(obj);

    }
}

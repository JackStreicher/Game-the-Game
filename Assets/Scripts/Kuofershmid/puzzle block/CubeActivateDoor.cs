using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeActivateDoor : MonoBehaviour
{
    public GameObject cube;

    public GameObject door;
    public float timeUntilDes;
    public float speed;
    public int up;
    bool isOpen = false;
        //fickt euch einfach nur selbst 

    // Update is called once per frame
    void Update()
    {
        if(isOpen == true)
        {
            StartCoroutine(desDoor());

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == cube)
        {
            isOpen = true;
            Debug.Log("Cube is in it");
        }
    }
    public IEnumerator desDoor()
    {
        for(int i = 0; i <= up;)
        {
            door.transform.Translate(Vector3.up *speed * Time.deltaTime);
            i++;
        }
        yield return new WaitForSeconds(timeUntilDes);
        isOpen = false;
    }
}

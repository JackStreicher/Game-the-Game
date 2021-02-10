using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeActivateDoor : MonoBehaviour
{
    //public string key;

    public GameObject door;
    private float timeUntilDes = 6;
    private float speed = 0.02f;
    private int up = 1000;
    bool isOpen = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isOpen == true)
        {
            StartCoroutine(desDoor());

        }
    }

   

    private void OnTriggerEnter(Collider other)
    {
        isOpen = false;
        //Debug.Log(other.name.Contains(key) + " " + key);
        if (other.name.Contains("key"))
        {
            //Debug.Log("Hit");
            isOpen = true;
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
        door.SetActive(false);
    }
}

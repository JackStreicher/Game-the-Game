using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScriptSceene : MonoBehaviour
{
    Scene scene;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        Debug.Log(scene.name);
        scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(scene.name == "Level 2")
        {
            SceneManager.LoadScene("The Crossing");

            Debug.Log(scene.name);
        }
        else
        {
            SceneManager.LoadScene("Level 2");

            Debug.Log(scene.name);
        }
        
        source.Play();
    }
}

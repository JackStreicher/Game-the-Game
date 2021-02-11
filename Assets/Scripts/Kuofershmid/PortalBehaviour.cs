using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    private string[] scenes = {"The Crossing", "Dungeon"};
    
    private void OnTriggerEnter(Collider other)
    {
        ChangeScene(SceneManager.GetActiveScene().name == "Dungeon" ? scenes[0] : scenes[1]);
    }

    private void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}

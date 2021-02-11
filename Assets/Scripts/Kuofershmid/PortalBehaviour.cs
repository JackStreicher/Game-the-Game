using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    public GameObject loadingScreenUi;
    public BoxCollider triggerPoint;
    public Scene theCrossingScene;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Do smth");
        ChangeScene();
    }

    private void ChangeScene(int _sceneIndex)
    {
        Debug.Log("he might do smth");
        if (!loadingScreenUi.activeSelf)
            loadingScreenUi.SetActive(true);

        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        Debug.Log("he is doing smth");
        AsyncOperation operation = SceneManager.LoadSceneAsync(//SCENE);

        yield return 0;
    }
}

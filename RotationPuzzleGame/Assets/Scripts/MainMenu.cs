using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject loadingScreen;

    public string firstLevel = "SampleScene";


    public void LoadFirst()
    {
        Debug.Log("LoadingScene...");
        StartCoroutine(LoadAsync(firstLevel));

    }

    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            yield return null;
        }
    }


    public void Quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}

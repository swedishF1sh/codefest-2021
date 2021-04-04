using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{

    public GameObject transitionBlack;
    public GameObject loadingScreen;


    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Next Level");

        LoadNext();

        

    }

    void OnTriggerExit(Collider colExit)
    {
        Debug.Log("Next Level");
    }



    public void LoadNext()
    {
        Debug.Log("LoadingScene...");
        StartCoroutine(LoadAsync());

    }

    IEnumerator LoadAsync()
    {
        

        transitionBlack.SetActive(true);
        

        yield return new WaitForSeconds(1.4f);
        
        loadingScreen.SetActive(true);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}

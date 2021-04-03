using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{



   
    public bool isPaused = false;
    public bool isInOptions = false;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    public GameObject camera;




    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        camera.GetComponent<CameraMovement>().enabled = true;
    }

    void Update()
    {
        if (isPaused)
            Cursor.visible = true;
        else
            Cursor.visible = false;

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {




            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            camera.GetComponent<CameraMovement>().enabled = false;
            Cursor.lockState = CursorLockMode.None;

            


        } else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
            Time.timeScale = 1f;
            camera.GetComponent<CameraMovement>().enabled = true;
        }
    }


    
        

    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
        camera.GetComponent<CameraMovement>().enabled = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    

    


}

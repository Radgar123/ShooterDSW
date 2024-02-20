using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject quitPopup;
    public GameObject pauseMenu;
    public Button continueButton, mainMenuButton, exitButton;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) 
        {

            PauseGame();
            
        }
    }



    public void QuitGame()
    {
        Application.Quit();
    }
    public void QuitPopup()
    {
        quitPopup.gameObject.SetActive(true);
        continueButton.enabled = false;
        mainMenuButton.enabled = false;
        exitButton.enabled = false;

    }

    public void StayInGame()
    {
        quitPopup.gameObject.SetActive(false);
        continueButton.enabled = true;
        mainMenuButton.enabled = true;
        exitButton.enabled = true;
    }

    public void PauseGame()
    {
        if (isPaused == false)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            isPaused = true;

        }
        else
        {
            
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            isPaused = false;
            StayInGame();
        }
       
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

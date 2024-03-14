using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject quitPopup;

    public Button quitButton, playButton, creditsButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        SceneManager.LoadScene(2);
    }

    public void Credits()
    {
        SceneManager.LoadScene(3);
    }



    public void QuitPopup()
    {
        quitPopup.gameObject.SetActive(true);
        quitButton.enabled = false;
        playButton.enabled = false;
        creditsButton.enabled = false;
        
         
    }

    public void StayInGame()
    {
        quitPopup.gameObject.SetActive(false);
        quitButton.enabled = true;
        playButton.enabled = true;
        creditsButton.enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

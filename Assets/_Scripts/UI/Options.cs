using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{

    public TextMeshProUGUI soundEffectsText, musicText;
    private bool soundON = true, musicON = true;



    private void Awake()
    {
     
    }
    // Start is called before the first frame update
    void Start()
    {
        if(BackgroundMusic.instance.audioSource.volume == 0)
        {
            musicText.text = "OFF";

        }
        else
        {
            musicText.text = "ON";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SoundEffects()
    {


        if (soundON)
        {
           
            soundEffectsText.text = "OFF";
            Debug.Log("SoundEffectsOFF");
            soundON = false;
        }
        else
        {
         
            soundEffectsText.text = "ON";
            Debug.Log("SoundEffectsON");
            soundON = true;

        }
    }

    public void Music()
    {
        if (musicON)
        {
            BackgroundMusic.instance.audioSource.volume = 0;
            musicText.text = "OFF";
            Debug.Log("MusicON");

                musicON = false;
        
        }

        else
        {
            BackgroundMusic.instance.audioSource.volume = 0.2f;
            musicText.text = "ON";
            Debug.Log("MusicOff");
                musicON = true;
            
        }
    }
}

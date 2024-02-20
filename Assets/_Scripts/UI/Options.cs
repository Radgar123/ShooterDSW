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
    // Start is called before the first frame update
    void Start()
    {
        
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
            musicText.text = "OFF";
            Debug.Log("MusicON");

                musicON = false;
        
        }

        else
        {
            musicText.text = "ON";
            Debug.Log("MusicOff");
                musicON = true;
            
        }
    }
}

using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
  
    public static BackgroundMusic instance;

    public AudioSource audioSource;
    public float volume;

    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
          
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

      
        PlayMusic();
    }

    public void PlayMusic()
    {
    
        if (!audioSource.isPlaying)
        {
            
            audioSource.Play();
        }
    }
}


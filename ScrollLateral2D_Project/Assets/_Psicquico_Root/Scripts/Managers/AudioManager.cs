using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Declaracion Singleton
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null) Debug.Log("No hay GameManager");
            return instance;
        }

    }

    //Fin del singleton

    public AudioSource musicSource;
    public AudioSource SFXSource;
    public AudioClip[] musicLibrary;
    public AudioClip[] SFXLibrary;

    private void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
        else
        {
            //Si ya hay GameManager, el duplicado se destruye
            Destroy(gameObject);
        }
    }

    public void PlayMusic(int musicToPlay)
    {
        musicSource.clip = musicLibrary[musicToPlay];
        musicSource.Play(); //Reproducir la musica desde el principio
    }

    public void PlaySFX(int sfxToPlay)
    {
        SFXSource.PlayOneShot(SFXLibrary[sfxToPlay]);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void UnPauseMusic()
    {
        musicSource.UnPause();
    }
}

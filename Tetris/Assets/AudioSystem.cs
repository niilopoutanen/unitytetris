using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSystem : MonoBehaviour
{
    public AudioSource player;

    public AudioClip keyPress1;
    public AudioClip keyPress2;
    public AudioClip keyPress3;
    public AudioClip keyPressSpace;

    public AudioClip switchToggle;
    public AudioClip buttonClick;

    public AudioSource gameMusic;

    public AudioClip pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            PlayGameMusic();
        }
    }
    public void PlayKeyPressed(KeyCode keyPressed)
    {
        if(keyPressed == KeyCode.Space)
        {
            player.PlayOneShot(keyPressSpace);
            return;
        }
        int randomIndex = Random.Range(0, 2);
        AudioClip[] clips = { keyPress1, keyPress2, keyPress3 };
        player.PlayOneShot(clips[randomIndex]);
    }
    public void PlaySwitchToggle()
    {
        player.PlayOneShot(switchToggle);
    }
    public void PlayButtonClick()
    {
        player.PlayOneShot(buttonClick);
    }
    public bool IsAudioRunning()
    {
        if (player.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void PlayGameMusic()
    {

    }
    public void PlayPauseMenu()
    {
        player.PlayOneShot(pauseMenuUI);

    }
    public void SetGameMusicVolume(float volume)
    {
        gameMusic.volume = volume;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}

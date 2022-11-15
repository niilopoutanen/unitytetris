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

    public AudioClip pauseMenuUI;

    public AudioSource musicStage1;
    public AudioSource musicStage1v2;
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
        if (!musicStage1.isPlaying)
        {
            musicStage1.Play();
            musicStage1.volume = 0.3f;
            Invoke(nameof(PlayGameMusic), 41.5f);
        }
        else if(!musicStage1v2.isPlaying)
        {
            musicStage1v2.Play();
            musicStage1v2.volume = 0.3f;
            Invoke(nameof(PlayGameMusic), 39.5f);
        }
    }
    public void PlayPauseMenu()
    {
        player.PlayOneShot(pauseMenuUI);

    }
    public void SetGameMusicVolume(float volume)
    {
        musicStage1.volume = volume;
        musicStage1v2.volume = volume;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}

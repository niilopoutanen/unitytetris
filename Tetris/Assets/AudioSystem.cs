using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public AudioSource player;

    public AudioClip keyPress1;
    public AudioClip keyPress2;
    public AudioClip keyPress3;
    public AudioClip keyPressSpace;

    public AudioClip switchToggle;
    public AudioClip buttonClick;

    // Start is called before the first frame update
    void Start()
    {
        
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
    // Update is called once per frame
    void Update()
    {
        
    }

}

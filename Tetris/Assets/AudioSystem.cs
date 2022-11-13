using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public AudioSource player;

    public AudioClip keyPress1;
    public AudioClip keyPress2;
    public AudioClip keyPress3;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PlayKeyPressed()
    {
        int randomIndex = Random.Range(0, 2);
        AudioClip[] clips = { keyPress1, keyPress2, keyPress3 };
        player.PlayOneShot(clips[randomIndex]);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}

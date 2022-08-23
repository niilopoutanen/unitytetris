using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIClass : MonoBehaviour
{

    [SerializeField] private AudioSource positive;
    public GameObject pauseCanvas;

    public void PauseMenu(bool isPaused)
    {
        if (isPaused == true)
        {
            pauseCanvas.SetActive(true);
        }
        else if (isPaused == false)
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1f;
            BlockLogic.paused = false;
        }
    }
    public void ResumeGame()
    {
        PauseMenu(false);
    }

    public void Play()
    {
        positive.Play();
    }
    public void UpdatePlayTime()
    {

    }
    void Start()
    {
        //pauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

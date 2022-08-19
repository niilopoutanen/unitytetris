using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIClass : MonoBehaviour
{

    [SerializeField] private AudioSource positive;
    public GameObject pausemenu;

    public void PauseMenu(bool isPaused)
    {
        if (isPaused == true)
        {
            pausemenu.SetActive(true);
        }
        else if (isPaused == false)
        {
            pausemenu.SetActive(false);
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseMenu(false);
        BlockLogic.paused = false;
    }

    public void Play()
    {
        positive.Play();
    }

    void Start()
    {
        pausemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

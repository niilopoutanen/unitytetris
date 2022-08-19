using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIClass : MonoBehaviour
{

    [SerializeField] private AudioSource positive;
    public GameObject pausemenu;
    private bool paused = false;

    public void PauseMenu(bool isPaused)
    {
        paused = isPaused;
        if (isPaused == true)
        {
            pausemenu.SetActive(true);
            paused = true;
        }
        else if (isPaused == false)
        {
            pausemenu.SetActive(false);
            paused = false;
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
    public bool ReturnPaused()
    {
        return paused;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIClass : MonoBehaviour
{

    [SerializeField] private AudioSource positive;
    [SerializeField] private GameObject pausemenu;
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
    public bool ResumeGame()
    {
        return true;
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
public class UIClass : MonoBehaviour
{

    [SerializeField] private AudioSource positive;
    public GameObject pauseCanvas;
    public Text SurvivedTime;
    public Text BlocksPlacedText;
    public Player player;

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
        FindObjectOfType<GameLogic>().GetEndTime();
        float Endtime = GameLogic.PlayTime;
        string[] splitted = Endtime.ToString().Split(',');
        if(splitted.Count() == 1)
        {
            splitted = Endtime.ToString().Split('.');
        }
        SurvivedTime.text = splitted[0];
    }

    public void UpdateBlocksPlaced()
    {
        BlocksPlacedText.text = GameLogic.BlocksPlaced.ToString();
    }
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseCanvas.activeSelf == false)
        {
            UpdatePlayTime();
            UpdateBlocksPlaced();
        }


    }
}

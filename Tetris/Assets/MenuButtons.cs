using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Discord;
using UnityEngine.Rendering;

public class MenuButtons : MonoBehaviour
{
    public void ToGithub()
    {
        string link = "https://github.com/niilopoutanen/UnityTetris";
        Application.OpenURL(link);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        GameLogic.ScoreValue = 0;
        GameLogic.BlocksPlaced = 0;
        GameLogic.gamespeed = 1f;
        GameLogic.timeOnStart = Time.time;
    }
    public void QuitGame()
    {
        Application.Quit();

    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ToAchievements()
    {
        SceneManager.LoadScene("Achievements");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

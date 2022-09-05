using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Discord;
using UnityEngine.Rendering;

public class MenuButtons : MonoBehaviour
{
    private LevelLoader levelLoader;
    private Player player;
    public void ToGithub()
    {
        string link = "https://github.com/niilopoutanen/UnityTetris";
        Application.OpenURL(link);
    }
    public void StartGame()
    {
        levelLoader.LoadNextLevel("Game");
        //SceneManager.LoadScene("Game");
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
        Time.timeScale = 1f;
        try
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            player.SavePlayer();
            Debug.Log("Player saved");
        }
        catch (System.Exception)
        {
            Debug.Log("Player save failed");
        }
        levelLoader.LoadNextLevel("Menu");
    }
    public void ToAchievements()
    {
        levelLoader.LoadNextLevel("Achievements");
    }
    // Start is called before the first frame update
    void Start()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

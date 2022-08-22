using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");
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

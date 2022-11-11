using UnityEngine;
using UnityEngine.SceneManagement;

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
        int audioOn = PlayerPrefs.GetInt("AudioOn", 1);
        if(audioOn == 0)
        {
            AudioListener.volume = 0;
        }
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
    public void ToMainMenu(bool saveGameNeeded)
    {
        Time.timeScale = 1f;
        if (saveGameNeeded)
        {
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
        }

        levelLoader.LoadNextLevel("Menu");
    }
    public void ToAchievements()
    {
        levelLoader.LoadNextLevel("Achievements");
    }

    public void ToSettings()
    {
        levelLoader.LoadNextLevel("Settings");
    }
    // Start is called before the first frame update
    void Start()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            int performanceOn = PlayerPrefs.GetInt("PerformanceOn");
            if (performanceOn == 1)
            {
                QualitySettings.SetQualityLevel(1);
            }
            else if (performanceOn == 0)
            {
                QualitySettings.SetQualityLevel(5);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

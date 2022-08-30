using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameOver : MonoBehaviour
{
    public Canvas Canvas;
    public Text ScoreText;
    public Text GameTime;
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GetScore()
    {
        Canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        ScoreText.text = "score: " + GameLogic.ScoreValue.ToString();

    }
    public void GetTime()
    {
        FindObjectOfType<GameLogic>().GetEndTime();
        float Endtime = GameLogic.PlayTime;
        string[] splitted = Endtime.ToString().Split(',');
        if (splitted.Count() == 1)
        {
            splitted = Endtime.ToString().Split('.');
        }
        GameTime.text = "Survival time: " + splitted[0] + " seconds";
    }
    // Start is called before the first frame update
    void Start()
    {
        GetScore();
        GetTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

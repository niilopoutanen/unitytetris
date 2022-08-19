using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Canvas Canvas;
    public Text ScoreText;
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GetScore()
    {
        Canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        ScoreText.text = "score: " + GameLogic.ScoreValue.ToString();

    }
    // Start is called before the first frame update
    void Start()
    {
        GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

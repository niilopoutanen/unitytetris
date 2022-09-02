using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.ComponentModel;

public class GameLogic : MonoBehaviour
{
    private static int width = 10;
    private static int height = 20;
    private static Transform[,] grid = new Transform[Width, Height];
    private static int scoreValue;
    private static int blocksPlaced;
    public static float gamespeed = 1.0f;
    public Canvas Canvas;
    public Text ScoreText;
    [SerializeField] private AudioSource positive;
    public static float timeOnStart;
    private float timeOnEnd;
    public static float PlayTime;
    public Player player;

    public static Transform[,] Grid { get => grid; set => grid = value; }
    public static int Height { get => height; set => height = value; }
    public static int Width { get => width; set => width = value; }
    public static int ScoreValue { get => scoreValue; set => scoreValue = value; }
    public static int BlocksPlaced { get => blocksPlaced; set => blocksPlaced = value; }

    public float GetEndTime()
    {
        timeOnEnd = Time.time;
        float time = timeOnStart + timeOnEnd;
        return time;
    }
    public Vector2 RoundVector(Vector2 vec)
    {
        return new Vector2(Mathf.Round(vec.x), Mathf.Round(vec.y));
    }
    public bool InsideGrid(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < Width && (int)pos.y >= 0);
    }

    public void DeleteRow(int y)
    {

        for (int x = 0; x < Width; ++x)
        {
            Destroy(Grid[x, y].gameObject);
            Grid[x, y] = null;

        }

    }

    public void DecreaseRow(int y)
    {
        for (int x = 0; x < Width; ++x)
        {
            if (Grid[x, y] != null)
            {
                Grid[x, y - 1] = Grid[x, y];
                Grid[x, y] = null;

                Grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }
    public void DecreaseTop(int y)
    {
        for (int i = y; i < Height; ++i)
        {
            DecreaseRow(i);
        }
    }
    public bool IsFull(int y)
    {
        for (int x = 0; x < Width; ++x)
        {
            if (Grid[x, y] == null)
            {
                return false;
            }
        }

        return true;
    }
    public float IncreaseSpeed()
    {
        float speed = gamespeed;
        speed = speed / 1.1f;
        gamespeed = speed;
        return speed;
    }
    public void DeleteRows()
    {
        player.BlocksPlaced++;
        for (int y = 0; y < Height; ++y)
        {
            if (IsFull(y))
            {

                IncreaseSpeed();
                Canvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
                ScoreText = Canvas.GetComponentInChildren<Text>();
                DeleteRow(y);
                DecreaseTop(y + 1);
                y--;
                ScoreValue++;
                ScoreText.text = ScoreValue.ToString();
                FindObjectOfType<UIClass>().Play();
            }
        }
    }
    public bool GameOver(Vector2 vec)
    {
        if(vec.y <18)
        {
            return false;

        }
        else
        {
            return false;
        }

    }

    public bool HasBlock(int y)
    {
        for (int x = 0; x < Width; ++x)
        {
            if(Grid[x, y] != null)
            {
                timeOnEnd = Time.time;
                return true;
            }
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayTime = Time.time - timeOnStart;
    }
}

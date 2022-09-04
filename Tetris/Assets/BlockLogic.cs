using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockLogic : MonoBehaviour
{
    public GameLogic logic;
    public bool gameover = false;
    public static bool paused = false;
    public Player player;
    [SerializeField] private AudioSource interact;

    bool ValidPos()
    {
        logic = gameObject.GetComponent<GameLogic>();

        foreach (Transform child in transform)
        {
            Vector2 vector = logic.RoundVector(child.position);

            if (!logic.InsideGrid(vector))
            {
                return false;
            }

            if (GameLogic.Grid[(int)vector.x, (int)vector.y] != null && GameLogic.Grid[(int)vector.x, (int)vector.y].parent != transform)
            {
                return false;
            }
        }
        return true;
    }
    void PlaySound(string sound)
    {
        if (sound == "interact")
        {
            interact.Play();
        }
    }
    void UpdateGrid()
    {
        logic = gameObject.GetComponent<GameLogic>();

        for (int y = 0; y < GameLogic.Height; y++)
        {
            for (int x = 0; x < GameLogic.Width; x++)
            {
                if (GameLogic.Grid[x, y] != null)
                {
                    if (GameLogic.Grid[x, y].parent == transform)
                    {
                        GameLogic.Grid[x, y] = null;
                    }
                }
            }
        }
 

        foreach (Transform child in transform)
        {
            Vector2 v = logic.RoundVector(child.position);
            GameLogic.Grid[(int)v.x, (int)v.y] = child;
        }
    }


    private void MoveBlock(string LeftRightDown)
    {
        if(LeftRightDown == "left")
        {
            if (Input.GetKey(KeyCode.LeftShift) == true)
            {
                transform.position += new Vector3(-1, 0, 0);

                if (ValidPos())
                {
                    PlaySound("interact");
                    UpdateGrid();
                }

                else
                {
                    transform.position += new Vector3(1, 0, 0);
                }
                transform.position += new Vector3(-1, 0, 0);

                if (ValidPos())
                {
                    PlaySound("interact");
                    UpdateGrid();
                }

                else
                {
                    transform.position += new Vector3(1, 0, 0);
                }
            }
            transform.position += new Vector3(-1, 0, 0);

            if (ValidPos())
            {
                PlaySound("interact");
                UpdateGrid();
            }

            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (LeftRightDown == "right")
        {
            if (Input.GetKey(KeyCode.LeftShift) == true)
            {
                transform.position += new Vector3(1, 0, 0);

                if (ValidPos())
                {
                    PlaySound("interact");
                    UpdateGrid();
                }
                else
                {
                    transform.position += new Vector3(-1, 0, 0);

                }
                transform.position += new Vector3(1, 0, 0);

                if (ValidPos())
                {
                    PlaySound("interact");
                    UpdateGrid();
                }
                else
                {
                    transform.position += new Vector3(-1, 0, 0);

                }
            }
            transform.position += new Vector3(1, 0, 0);

            if (ValidPos())
            {
                PlaySound("interact");
                UpdateGrid();
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);

            }
        }
    }
    private void RotateBlock()
    {
        transform.Rotate(0, 0, -90);

        if (ValidPos())
        {
            PlaySound("interact");
            UpdateGrid();
        }
        else
        {
            transform.Rotate(0, 0, 90);
        }
    }

    private void MoveBlockDown(bool isSpace)
    {
        if (isSpace == false)
        {
            transform.position += new Vector3(0, -1, 0);

            if (ValidPos())
            {
                UpdateGrid();
            }

            //Tarkistaa onko rivi täynnä ja spawnaa uuden palan
            else
            {
                transform.position += new Vector3(0, 1, 0);

                logic.DeleteRows();

                if (logic.HasBlock(17))
                {
                    OnGameOver();
                }

                FindObjectOfType<Spawner>().SpawnNext();

                enabled = false;
            }

            Fall = Time.time;
        }
        else if (isSpace == true)
        {
            while (true)
            {
                transform.position += new Vector3(0, -1, 0);

                if (ValidPos())
                {
                    PlaySound("interact");
                    UpdateGrid();
                }

                //Tarkistaa onko rivi täynnä ja spawnaa uuden palan
                else
                {
                    transform.position += new Vector3(0, 1, 0);
                    logic.DeleteRows();
                    if (logic.HasBlock(17))
                    {
                        OnGameOver();
                    }
                    FindObjectOfType<Spawner>().SpawnNext();

                    enabled = false;
                    break;
                }

                Fall = Time.time;
            }
        }
    }

    private void OnGameOver()
    {
        gameover = true;
        FindObjectOfType<GameLogic>().GetEndTime();
        SceneManager.LoadScene("Game Over");


        player.AddBlock(GameLogic.BlocksPlaced);
        player.AddTimes("timesPlayed");
        player.CheckHighScore(GameLogic.ScoreValue);
        player.SavePlayer();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

        FindObjectOfType<UIClass>().PauseMenu(false);

        if (!ValidPos())
        {
            Destroy(gameObject);
        }
    }


    float Fall = 0;
    // Update is called once per frame
    void Update()
    {
        if(gameover == false)
        {
            if(paused == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Time.timeScale = 0f;
                    FindObjectOfType<UIClass>().PauseMenu(true);
                    paused = true;

                }
                //vasemmalle

                else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    MoveBlock("left");
                }
                //oikealle
                else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    MoveBlock("right");
                }
                //Pyöritä
                else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    RotateBlock();
                }

                //Nopeammin alas
                else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - Fall >= GameLogic.gamespeed || Input.GetKeyDown(KeyCode.S))
                {
                    MoveBlockDown(false);
                }
                else if (Input.GetKeyDown(KeyCode.Space) || Time.time - Fall >= GameLogic.gamespeed)
                {
                    MoveBlockDown(true);
                }
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    PlaySound("interact");
                }
            }
            else if (paused == true)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    FindObjectOfType<UIClass>().PauseMenu(false);
                    paused = false;
                }
            }
        }
    }
}

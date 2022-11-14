using UnityEngine;

public class BlockLogic : MonoBehaviour
{
    public GameLogic logic;
    public bool gameover = false;
    public static bool paused = false;
    public Player player;
    public AudioSystem audioSystem; 
    private Camera cam;
    private bool prefersMouseControls = false;
    bool ValidPosition()
    {
        logic = gameObject.GetComponent<GameLogic>();

        foreach (Transform child in transform)
        {
            Vector2 vector = logic.RoundPosition(child.position);

            if (!logic.IsInsideGrid(vector))
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
            Vector2 v = logic.RoundPosition(child.position);
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

                if (ValidPosition())
                {
                    UpdateGrid();
                }

                else
                {
                    transform.position += new Vector3(1, 0, 0);
                }
                transform.position += new Vector3(-1, 0, 0);

                if (ValidPosition())
                {
                    UpdateGrid();
                }

                else
                {
                    transform.position += new Vector3(1, 0, 0);
                }
            }
            transform.position += new Vector3(-1, 0, 0);

            if (ValidPosition())
            {
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

                if (ValidPosition())
                {
                    UpdateGrid();
                }
                else
                {
                    transform.position += new Vector3(-1, 0, 0);

                }
                transform.position += new Vector3(1, 0, 0);

                if (ValidPosition())
                {
                    UpdateGrid();
                }
                else
                {
                    transform.position += new Vector3(-1, 0, 0);

                }
            }
            transform.position += new Vector3(1, 0, 0);

            if (ValidPosition())
            {
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

        if (ValidPosition())
        {
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

            if (ValidPosition())
            {
                UpdateGrid();
                
            }

            //Tarkistaa onko rivi täynnä ja spawnaa uuden palan
            else
            {
                transform.position += new Vector3(0, 1, 0);

                logic.ClearRows();

                if (logic.HasBlock(17))
                {
                    OnGameOver();
                }
                if (logic.HasBlock(18))
                {
                    OnGameOver();
                }
                if (logic.HasBlock(19))
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

                if (ValidPosition())
                {
                    UpdateGrid();
                }

                //Tarkistaa onko rivi täynnä ja spawnaa uuden palan
                else
                {
                    transform.position += new Vector3(0, 1, 0);
                    logic.ClearRows();
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
        LevelLoader levelloader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        levelloader.LoadNextLevel("Game Over");
        //SceneManager.LoadScene("Game Over");

        player.LoadPlayer();
        player.AddBlock(GameLogic.BlocksPlaced);
        player.AddTimes("timesPlayed");
        player.CheckHighScore(GameLogic.ScoreValue);
        player.SavePlayer();
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        audioSystem = cam.GetComponent<AudioSystem>();
        player = GameObject.Find("Player").GetComponent<Player>();

        FindObjectOfType<UIClass>().PauseMenu(false);
        prefersMouseControls = PlayerPrefs.GetInt("MouseControls") != 0;
        if (!ValidPosition())
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
                else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    audioSystem.PlayKeyPressed(KeyCode.A);
                    MoveBlock("left");
                }

                else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    audioSystem.PlayKeyPressed(KeyCode.D);
                    MoveBlock("right");
                }

                else if (prefersMouseControls)
                {
                    if (Input.GetAxis("Mouse X") < 0)
                    {
                        if (Input.mousePosition.x < cam.WorldToScreenPoint(transform.position).x)
                        {
                            if (cam.WorldToScreenPoint(transform.position).x - Input.mousePosition.x > 20)
                            {
                                MoveBlock("left");
                            }
                        }
                    }

                    if (Input.GetAxis("Mouse X") > 0)
                    {
                        if (Input.mousePosition.x > cam.WorldToScreenPoint(transform.position).x)
                        {
                            if (Input.mousePosition.x - cam.WorldToScreenPoint(transform.position).x > 20)
                            {
                                MoveBlock("right");
                            }
                        }
                    }
                    if (Input.GetMouseButtonDown(1))
                    {
                        audioSystem.PlayKeyPressed(KeyCode.Mouse0);
                        RotateBlock();
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        audioSystem.PlayKeyPressed(KeyCode.Mouse0);
                        MoveBlockDown(true);
                    }
                    if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                    {
                        MoveBlockDown(false);
                    }
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    audioSystem.PlayKeyPressed(KeyCode.W);
                    RotateBlock();
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - Fall >= GameLogic.gamespeed || Input.GetKeyDown(KeyCode.S))
                {
                    MoveBlockDown(false);
                }
                if (Input.GetKeyDown(KeyCode.Space) || Time.time - Fall >= GameLogic.gamespeed)
                {
                    MoveBlockDown(true);
                }

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    audioSystem.PlayKeyPressed(KeyCode.Space);
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

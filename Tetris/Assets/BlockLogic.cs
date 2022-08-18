using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockLogic : MonoBehaviour
{
    public GameLogic logic;
    public bool gameover = false;
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
    // Start is called before the first frame update
    void Start()
    {

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
            //vasemmalle
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-1, 0, 0);

                if (ValidPos())
                    UpdateGrid();
                else
                    transform.position += new Vector3(1, 0, 0);
            }
            //oikealle
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += new Vector3(1, 0, 0);

                if (ValidPos())
                {
                    UpdateGrid();
                }
                else
                {
                    transform.position += new Vector3(-1, 0, 0);

                }
            }
            //Pyöritä
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Rotate(0, 0, -90);

                if (ValidPos())
                {
                    UpdateGrid();
                }
                else
                {
                    transform.Rotate(0, 0, 90);
                }
            }

            //Nopeammin alas
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - Fall >= 1)
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
                        gameover = true;
                        SceneManager.LoadScene("Game Over");
                    }

                    FindObjectOfType<Spawner>().SpawnNext();

                    enabled = false;
                }

                Fall = Time.time;
            }
            else if (Input.GetKeyDown(KeyCode.Space) || Time.time - Fall >= 1)
            {
                while (true)
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
                                gameover = true;
                            SceneManager.LoadScene("Game Over");
                        }
                        FindObjectOfType<Spawner>().SpawnNext();

                        enabled = false;
                        break;
                    }

                    Fall = Time.time;
                }
            }
        }


    }
}

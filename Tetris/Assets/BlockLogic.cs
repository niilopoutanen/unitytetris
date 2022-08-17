using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLogic : MonoBehaviour
{
    bool ValidPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 vector = GameLogic.RoundVector(child.position);

            if (!GameLogic.InsideGrid(vector))
            {
                return false;
            }

            if (GameLogic.grid[(int)vector.x, (int)vector.y] != null && GameLogic.grid[(int)vector.x, (int)vector.y].parent != transform)
            {
                return false;
            }
        }
        return true;
    }
    void UpdateGrid()
    {
        for (int y = 0; y < GameLogic.height; y++)
        {
            for (int x = 0; x < GameLogic.width; x++)
            {
                if (GameLogic.grid[x, y] != null)
                {
                    if (GameLogic.grid[x, y].parent == transform)
                    {
                        GameLogic.grid[x, y] = null;
                    }
                }
            }
        }
 

        foreach (Transform child in transform)
        {
            Vector2 v = GameLogic.RoundVector(child.position);
            GameLogic.grid[(int)v.x, (int)v.y] = child;
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
        else if (Input.GetKeyDown(KeyCode.DownArrow) ||Time.time - Fall >= 1)
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

                GameLogic.DeleteRows();

                FindObjectOfType<Spawner>().SpawnNext();

                enabled = false;
            }

            Fall = Time.time;
        }
    }
}

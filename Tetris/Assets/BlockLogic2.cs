using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLogic2 : MonoBehaviour
{
    bool ValidPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = GameLogic2.RoundVector(child.position);

            if (!GameLogic2.InsideGrid(v))
                return false;

            if (GameLogic2.grid[(int)v.x, (int)v.y] != null &&
                GameLogic2.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }
    void UpdateGrid()
    {
        for (int y = 0; y < GameLogic2.height; ++y)
            for (int x = 0; x < GameLogic2.width; ++x)
                if (GameLogic2.grid[x, y] != null)
                    if (GameLogic2.grid[x, y].parent == transform)
                        GameLogic2.grid[x, y] = null;

        foreach (Transform child in transform)
        {
            Vector2 v = GameLogic2.RoundVector(child.position);
            GameLogic2.grid[(int)v.x, (int)v.y] = child;
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

    float lastFall = 0;
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

        else if (Input.GetKeyDown(KeyCode.DownArrow) ||
                 Time.time - lastFall >= 1)
        {
            transform.position += new Vector3(0, -1, 0);

            if (ValidPos())
            {
                UpdateGrid();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);

                GameLogic2.DeleteRows();

                FindObjectOfType<Spawner>().SpawnNext();

                enabled = false;
            }

            lastFall = Time.time;
        }
    }
}

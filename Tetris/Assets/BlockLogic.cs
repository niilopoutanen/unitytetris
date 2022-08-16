using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLogic : MonoBehaviour
{
    float timer = 0f;
    bool movable = true;
    public GameObject rig;


    private bool ValidateMove()
    {
        foreach (Transform subBlock in rig.transform)
        {
            if(subBlock.transform.position.x > GameLogic.width ||
                subBlock.transform.position.x < 1 ||
                subBlock.transform.position.y < 0)
            {
                return false;
            }
        }

        //if(pos.x > 9)
        //{
        //    return false;
        //}
        //if (pos.x < 2)
        //{
        //    return false;
        //}
        //else if (pos.y < 1)
        //{
        //    return false;
        //}
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movable)
        {
            timer += 1 * Time.deltaTime;

            if (Input.GetKey(KeyCode.DownArrow) && timer > GameLogic.quickdropspeed)
            {
                gameObject.transform.position -= new Vector3(0, 1, 0);
                timer = 0;
                if (!(ValidateMove()))
                {
                    movable = false;
                    gameObject.transform.position += new Vector3(0, 1, 0);

                }
            }
            else if (timer > GameLogic.dropspeed)
            {
                gameObject.transform.position += new Vector3(0, -1, 0);
                timer = 0;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                gameObject.transform.position -= new Vector3(1, 0, 0);
                if (!(ValidateMove()))
                {
                    gameObject.transform.position += new Vector3(1, 0, 0);

                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                gameObject.transform.position += new Vector3(1, 0, 0);
                if (!(ValidateMove()))
                {
                    gameObject.transform.position -= new Vector3(1, 0, 0);

                }
            }

            //pyöritys

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rig.transform.eulerAngles -= new Vector3(0, 0, 90);
                if (!(ValidateMove()))
                {
                    rig.transform.eulerAngles += new Vector3(0, 0, 90);
    
                }
            }

        }


    }
}

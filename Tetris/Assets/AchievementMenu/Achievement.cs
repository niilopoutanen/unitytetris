using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Achievement : MonoBehaviour
{
    public int totalBlocks = 500;


    public bool CheckIfDone(int requirement, int value)
    {
        if (requirement < value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    public Player player;
    public Text playertotalBlocks;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        player.LoadPlayer();

        if (CheckIfDone(totalBlocks, player.blocksPlaced) == true)
        {
            playertotalBlocks.text = "done";
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AchievementSystem : MonoBehaviour
{
    private Achievement achievements;

    public Player player;
    public Text totalBlocks;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        player.LoadPlayer();

        if(achievements.CheckIfDone(achievements.totalBlocks, player.blocksPlaced) == true)
        {
            totalBlocks.text = "done";
        }
    }

}
public class Achievement
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

}

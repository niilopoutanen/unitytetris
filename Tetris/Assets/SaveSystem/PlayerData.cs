using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public int highScore;
    public int blocksPlaced;
    public int totalPlayTime;

    public PlayerData (Player player)
    {
        highScore = Player.Score;
        blocksPlaced = player.BlocksPlaced;
        totalPlayTime = 1;
    }
}

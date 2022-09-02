using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public int blocksPlaced;

    public PlayerData (Player player)
    {
        blocksPlaced = player.blocksPlaced;
    }
}

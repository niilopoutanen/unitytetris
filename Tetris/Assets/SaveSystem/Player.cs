using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static int score;
    private int blocksPlaced;

    public static int Score { get => score; set => score = value; }
    public int BlocksPlaced { get => blocksPlaced; set => blocksPlaced = value; }

    public void SavePlayer()
    {
        SaveSystem.SaveData(this);
        Debug.Log("Saved");
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadData();

        Score = data.highScore;
        BlocksPlaced = data.blocksPlaced;
        Debug.Log("Loaded");
    }

}

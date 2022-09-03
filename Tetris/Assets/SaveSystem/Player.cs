using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int blocksPlaced;
    public int scoreOver20Times;
    public bool hasPlayedAGame;
    public void SavePlayer()
    {
        SaveSystem.SaveData(this);
        Debug.Log("Saved" + this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadData();

        blocksPlaced = data.blocksPlaced;
        scoreOver20Times = data.scoreOver20Times;
        hasPlayedAGame = data.hasPlayedAGame;
        Debug.Log("Loaded" + data.ToString());
    }
    public void AddBlock(int sessionblocks)
    {
        blocksPlaced += sessionblocks;
    }
    public void AddTimes(string toWhat)
    {
        if(toWhat == "scoreOver20Times")
        {
            scoreOver20Times++;
        }
    }
    private void Start()
    {
        LoadPlayer();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int blocksPlaced;
    public int scoreOver20Times;
    public int timesPlayed;
    public int highScore;
    public void SavePlayer()
    {
        SaveSystem.SaveData(this);
        Debug.Log("Saved" + this);
    }
    public void LoadPlayer()
    {
        try
        {
            PlayerData data = SaveSystem.LoadData();

            blocksPlaced = data.blocksPlaced;
            scoreOver20Times = data.scoreOver20Times;
            timesPlayed = data.timesPlayed;
            highScore = data.highScore;
            Debug.Log("Loaded" + data.ToString());
        }
        catch (System.Exception)
        {
            Debug.Log("player not found");
        }
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
        else if(toWhat == "timesPlayed")
        {
            timesPlayed++;
        }
    }
    public void CheckHighScore(int currentscore)
    {
        if(highScore < currentscore)
        {
            highScore = currentscore;
        }
    }
    private void Start()
    {
        LoadPlayer();
    }
}

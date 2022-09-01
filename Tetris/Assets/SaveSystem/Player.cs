using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score;
    public int blocksPlaced;

    public void SavePlayer()
    {
        SaveSystem.SaveData(this);
        Debug.Log("Saved");
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadData();

        score = data.highScore;
        blocksPlaced = data.blocksPlaced;
        Debug.Log("Loaded");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int blocksPlaced;

    public void SavePlayer()
    {
        SaveSystem.SaveData(this);
        Debug.Log("Saved, BlocksPlaced = " + blocksPlaced);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadData();

        blocksPlaced = data.blocksPlaced;
        Debug.Log("Loaded, BlocksPlaced = " + blocksPlaced);
    }
    public void AddBlock(int sessionblocks)
    {
        Debug.Log("new blocksplaced amount. " + blocksPlaced);
        blocksPlaced += sessionblocks;
    }
    private void Start()
    {
        LoadPlayer();
    }
}

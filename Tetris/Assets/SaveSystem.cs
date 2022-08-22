using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    string testipolku = "C:\\Users\\Niilo Poutanen\\AppData\\LocalLow\\Niilo Poutanen\\Tetris\\testi.txt";
    string polku = Application.persistentDataPath + "\testi.txt";
    public void SaveScores(int score, string player)
    {
        using (StreamWriter writer = new StreamWriter(testipolku))
        {
            writer.Write(score);
            writer.Write(player);
        };
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

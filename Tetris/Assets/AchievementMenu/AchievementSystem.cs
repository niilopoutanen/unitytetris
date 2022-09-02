using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AchievementSystem : MonoBehaviour
{

    public Player player;
    public Text totalBlocks;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        player.LoadPlayer();
        totalBlocks.text = player.blocksPlaced.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AchievementSystem(string AchievementName, string AchievementDescription, int requirement)
    {

    }


}
public class AchivementClass
{
    private int totalBlocks = 500;
    private int scoreOver20times = 20;


    private void CheckIfDone(int requirement, int value)
    {

    }

}

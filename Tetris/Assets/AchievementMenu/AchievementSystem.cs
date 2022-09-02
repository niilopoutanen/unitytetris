using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}

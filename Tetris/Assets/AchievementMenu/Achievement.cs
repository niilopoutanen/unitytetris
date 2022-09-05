using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public GameObject content;
    public GameObject statsPanel;
    public Text highScoreText;
    public Text blocksPlacedText;
    public Text gamesPlayedText;

    public bool CheckIfDone(int requirement, int value)
    {
        if (requirement < value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ChangeVisibility(bool isSilver,string componentName)
    {
        GameObject tochange = GameObject.Find(componentName);

        if (isSilver == true)
        {
            tochange.transform.Find("Silver").gameObject.SetActive(true);
            tochange.transform.Find("Locked").gameObject.SetActive(false);
        }
        if(isSilver == false)
        {
            tochange.transform.Find("Gold").gameObject.SetActive(true);
            tochange.transform.Find("Locked").gameObject.SetActive(false);
        }
        tochange.tag = "Unlocked";


        Transform icon = tochange.transform.Find("Icon");
        icon.gameObject.SetActive(true);
    }

    public Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        player.LoadPlayer();

        if (CheckIfDone(500, player.blocksPlaced) == true)
        {
            ChangeVisibility(false, "500Blocks");
        }

        if (CheckIfDone(10, player.scoreOver20Times) == true)
        {
            ChangeVisibility(false, "20Score10Times");

        }
        if(player.timesPlayed >= 1)
        {
            ChangeVisibility(true, "FirstGame");
        }
        if(player.timesPlayed >= 10)
        {
            ChangeVisibility(true, "10Games");
        }
        if(player.highScore >= 20)
        {
            ChangeVisibility(false, "ScoreOver20");
        }
        if(player.timesPlayed >= 5)
        {
            ChangeVisibility(true, "5Games");
        }
        if(player.blocksPlaced >= 100)
        {
            ChangeVisibility(true, "100Blocks");
        }
        if(player.highScore >= 10)
        {
            ChangeVisibility(true, "ScoreOver10");
        }
        foreach (Transform child in content.transform)
        {
            if(child.tag == "Unlocked")
            {
                child.SetAsFirstSibling();
            }
        }

        statsPanel.transform.SetAsFirstSibling(); ;
        highScoreText.text = player.highScore.ToString();
        blocksPlacedText.text = player.blocksPlaced.ToString();
        gamesPlayedText.text = player.timesPlayed.ToString();

    }

}

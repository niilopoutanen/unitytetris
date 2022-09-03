using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    private int totalBlocks = 500;
    private int ScoreOver20times = 10;
    public GameObject content;

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
        //icon.GetComponent<Image>().color = new Color(1,1,1,1);
    }

    public Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        player.LoadPlayer();

        if (CheckIfDone(totalBlocks, player.blocksPlaced) == true)
        {
            ChangeVisibility(true, "500Blocks");
        }

        if (CheckIfDone(ScoreOver20times, player.scoreOver20Times) == true)
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
        if(ScoreOver20times >= 1)
        {
            ChangeVisibility(true, "ScoreOver20");
        }
        if (ScoreOver20times >= 1)
        {
            ChangeVisibility(true, "ScoreOver20");
        }


        foreach (Transform child in content.transform)
        {
            if(child.tag == "Unlocked")
            {
                child.SetAsFirstSibling();
            }
        }
    }

}

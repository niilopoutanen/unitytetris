
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public GameObject content;
    public GameObject statsPanel;
    public Text highScoreText;
    public Text blocksPlacedText;
    public Text gamesPlayedText;
    public MenuButtons menucode;
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
    public void ChangeVisibility(string componentName)
    {
        GameObject tochange = GameObject.Find(componentName);

        tochange.transform.Find("Unlocked").gameObject.SetActive(true);
        tochange.transform.Find("Locked").gameObject.SetActive(false);
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
            ChangeVisibility("500Blocks");
        }

        if (CheckIfDone(10, player.scoreOver20Times) == true)
        {
            ChangeVisibility("20Score10Times");

        }
        if(player.timesPlayed >= 1)
        {
            ChangeVisibility("FirstGame");
        }
        if(player.timesPlayed >= 10)
        {
            ChangeVisibility("10Games");
        }
        if(player.highScore >= 20)
        {
            ChangeVisibility("ScoreOver20");
        }
        if(player.timesPlayed >= 5)
        {
            ChangeVisibility("5Games");
        }
        if(player.blocksPlaced >= 100)
        {
            ChangeVisibility("100Blocks");
        }
        if(player.highScore >= 10)
        {
            ChangeVisibility("ScoreOver10");
        }
        if (player.blocksPlaced >= 1000)
        {
            ChangeVisibility("1000Blocks");
        }
        if (player.timesPlayed >= 20)
        {
            ChangeVisibility("20Games");
        }
        foreach (Transform child in content.transform)
        {
            if(child.tag == "Unlocked")
            {
                child.SetAsFirstSibling();
            }
        }
        statsPanel.transform.SetAsFirstSibling();

        highScoreText.text = player.highScore.ToString();
        blocksPlacedText.text = player.blocksPlaced.ToString();
        gamesPlayedText.text = player.timesPlayed.ToString();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menucode.ToMainMenu(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ColorSystem : MonoBehaviour
{
    public ParticleSystem particleSys;
    public Text[] textElements;
    public GameObject[] gameImages;


    public GameObject menuBg;
    public SpriteRenderer menuLogo;
    public GameObject[] menuButtons;


    public GameObject settingsBg;

    public GameObject achievementsBg;
    public Image[] achievementImages;
    public GameObject[] achievementCards;

    public Text gameOverText;
    public Image gameOverBg;

    private static Color purple = new(219, 0, 255);
    private static Color blue = new(0, 0, 255);
    private static Color red = new(255, 0, 0);
    private static Color green = new(0, 255, 0);

    private string theme;
    // Start is called before the first frame update
    void Start()
    {
        theme = PlayerPrefs.GetString("PreferredColorTheme", "Purple");
        switch (SceneManager.GetActiveScene().name)
        {
            case "Game":
                SetGameColors();
                break;
            case "Menu":
                SetMenuColors();
                break;
            case "Settings":
                SetSettingsColors();
                break;
            case "Achievements":
                SetAchievementsColors();
                break;
            case "Game Over":
                SetGameOverColors();
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetGameColors()
    {
        Color selectedColor = purple;
        switch (theme)
        {
            case "Purple":
                selectedColor = purple;
                break;

            case "Blue":
                selectedColor = blue;
                break;

            case "Red":
                selectedColor = red;
                break;

            case "Green":
                selectedColor = green;
                break;
        }
        var main = particleSys.main;

        main.startColor = selectedColor;
        foreach (GameObject gameObject in gameImages)
        {
            try
            {
                gameObject.GetComponent<SpriteRenderer>().color = selectedColor;
            }
            catch
            {
                gameObject.GetComponent<Image>().color = selectedColor;
            }
        }
        foreach (Text textElement in textElements)
        {
            textElement.color = selectedColor;
        }
    }
    public void SetMenuColors()
    {
        Color selectedColor = purple;
        switch (theme)
        {
            case "Purple":
                selectedColor = purple;
                break;

            case "Blue":
                selectedColor = blue;
                break;

            case "Red":
                selectedColor = red;
                break;

            case "Green":
                selectedColor = green;
                break;
        }
        menuBg.GetComponent<SpriteRenderer>().color = selectedColor;
        menuLogo.color = selectedColor;
        foreach (GameObject button in menuButtons)
        {
            button.GetComponent<Image>().color = selectedColor;
        }
    }
    public void SetSettingsColors()
    {
        theme = PlayerPrefs.GetString("PreferredColorTheme", "Purple");
        Color selectedColor = purple;
        switch (theme)
        {
            case "Purple":
                selectedColor = purple;
                break;

            case "Blue":
                selectedColor = blue;
                break;

            case "Red":
                selectedColor = red;
                break;

            case "Green":
                selectedColor = green;
                break;
        }
        settingsBg.GetComponent<SpriteRenderer>().color = selectedColor;

    }

    public void SetAchievementsColors()
    {
        Color selectedColor = purple;
        switch (theme)
        {
            case "Purple":
                selectedColor = purple;
                break;

            case "Blue":
                selectedColor = blue;
                break;

            case "Red":
                selectedColor = red;
                break;

            case "Green":
                selectedColor = green;
                break;
        }
        achievementsBg.GetComponent<SpriteRenderer>().color = selectedColor;
        foreach (Image achievementImage in achievementImages)
        {
            achievementImage.color = selectedColor;
        }
        foreach (GameObject achievementCard in achievementCards)
        {
            achievementCard.transform.Find("Unlocked").gameObject.GetComponent<Image>().color = selectedColor;
            achievementCard.transform.Find("Locked").gameObject.GetComponent<Image>().color = selectedColor;
            achievementCard.transform.Find("Icon").gameObject.GetComponent<Image>().color = selectedColor;
        }
    }
    public void SetGameOverColors()
    {
        Color selectedColor = purple;
        switch (theme)
        {
            case "Purple":
                selectedColor = purple;
                break;

            case "Blue":
                selectedColor = blue;
                break;

            case "Red":
                selectedColor = red;
                break;

            case "Green":
                selectedColor = green;
                break;
        }
        gameOverBg.color = selectedColor;
        gameOverText.color = selectedColor;
    }
    public static Color GetColor()
    {
        var theme = PlayerPrefs.GetString("PreferredColorTheme", "Purple");
        switch (theme)
        {
            case "Purple":
                return purple;

            case "Blue":
                return blue;

            case "Red":
                return red;

            case "Green":
                return green;
        }
        return purple;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ColorSystem : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    public Text[] textElements;
    public GameObject[] gameImages;
    public GameObject menuBg;
    public GameObject[] menuButtons;


    public GameObject settingsBg;

    public GameObject achievementsBg;
    public Image[] achievementImages;

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
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetGameColors()
    {
        var main = particleSystem.main;

        switch (theme)
        {
            case "Purple":
                main.startColor = purple;
                foreach (GameObject gameObject in gameImages)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = purple;
                }
                foreach (Text textElement in textElements)
                {
                    textElement.color = purple;
                }
                break;

            case "Blue":
                main.startColor = blue;
                foreach (GameObject gameObject in gameImages)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = blue;
                }
                foreach (Text textElement in textElements)
                {
                    textElement.color = blue;
                }
                break;

            case "Red":
                main.startColor = red;
                foreach (GameObject gameObject in gameImages)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = red;
                }

                foreach (Text textElement in textElements)
                {
                    textElement.color = red;
                }
                break;

            case "Green":
                main.startColor = green;
                foreach (GameObject gameObject in gameImages)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = green;
                }

                foreach (Text textElement in textElements)
                {
                    textElement.color = green;
                }
                break;
        }
    }
    public void SetMenuColors()
    {
        
        switch (theme)
        {
            case "Purple":
                menuBg.GetComponent<SpriteRenderer>().color = purple;
                foreach (GameObject button in menuButtons)
                {
                    button.GetComponent<Image>().color = purple;
                }
                break;

            case "Blue":
                menuBg.GetComponent<SpriteRenderer>().color = blue;
                foreach (GameObject button in menuButtons)
                {
                    button.GetComponent<Image>().color = blue;
                }
                break;

            case "Red":
                menuBg.GetComponent<SpriteRenderer>().color = red;
                foreach (GameObject button in menuButtons)
                {
                    button.GetComponent<Image>().color = red;
                }
                break;

            case "Green":
                menuBg.GetComponent<SpriteRenderer>().color = green;
                foreach (GameObject button in menuButtons)
                {
                    button.GetComponent<Image>().color = green;
                }
                break;
        }
    }
    public void SetSettingsColors()
    {
        theme = PlayerPrefs.GetString("PreferredColorTheme", "Purple");
        switch (theme)
        {
            case "Purple":
                settingsBg.GetComponent<SpriteRenderer>().color = purple;
                break;

            case "Blue":
                settingsBg.GetComponent<SpriteRenderer>().color = blue;
                break;

            case "Red":
                settingsBg.GetComponent<SpriteRenderer>().color = red;
                break;

            case "Green":
                settingsBg.GetComponent<SpriteRenderer>().color = green;
                break;
        }
    }

    public void SetAchievementsColors()
    {
        switch (theme)
        {
            case "Purple":
                achievementsBg.GetComponent<SpriteRenderer>().color = purple;
                foreach (Image achievementImage in achievementImages)
                {
                    achievementImage.color = purple;
                }
                break;

            case "Blue":
                achievementsBg.GetComponent<SpriteRenderer>().color = blue;
                foreach (Image achievementImage in achievementImages)
                {
                    achievementImage.color = blue;
                }
                break;

            case "Red":
                achievementsBg.GetComponent<SpriteRenderer>().color = red;
                foreach (Image achievementImage in achievementImages)
                {
                    achievementImage.color = red;
                }
                break;

            case "Green":
                achievementsBg.GetComponent<SpriteRenderer>().color = green;
                foreach (Image achievementImage in achievementImages)
                {
                    achievementImage.color = green;
                }
                break;
        }
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

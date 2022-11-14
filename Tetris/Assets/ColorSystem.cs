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
    public GameObject grid;
    public Text[] textElements;
    public GameObject scoreBg;

    public GameObject menuBg;
    public GameObject[] menuButtons;


    public GameObject settingsBg;

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
                grid.GetComponent<SpriteRenderer>().color = purple;
                scoreBg.GetComponent<SpriteRenderer>().color = purple;
                foreach (Text textElement in textElements)
                {
                    textElement.color = purple;
                }
                break;

            case "Blue":
                main.startColor = blue;
                grid.GetComponent<SpriteRenderer>().color = blue;
                scoreBg.GetComponent<SpriteRenderer>().color = blue;

                foreach (Text textElement in textElements)
                {
                    textElement.color = blue;
                }
                break;

            case "Red":
                main.startColor = red;
                grid.GetComponent<SpriteRenderer>().color = red;
                scoreBg.GetComponent<SpriteRenderer>().color = red;

                foreach (Text textElement in textElements)
                {
                    textElement.color = red;
                }
                break;

            case "Green":
                main.startColor = green;
                grid.GetComponent<SpriteRenderer>().color = green;
                scoreBg.GetComponent<SpriteRenderer>().color = green;

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
}

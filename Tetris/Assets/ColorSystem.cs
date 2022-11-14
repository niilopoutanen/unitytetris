using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class ColorSystem : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    public GameObject grid;

    public GameObject menuBG;

    public GameObject settingsBg;

    private Color purple = new(219, 0, 255);
    private Color blue = new(0, 0, 255);
    private Color red = new(255, 0, 0);
    private Color green = new(0, 255, 0);

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
                break;

            case "Blue":
                main.startColor = blue;
                grid.GetComponent<SpriteRenderer>().color = blue;
                break;

            case "Red":
                main.startColor = red;
                grid.GetComponent<SpriteRenderer>().color = red;
                break;

            case "Green":
                main.startColor = green;
                grid.GetComponent<SpriteRenderer>().color = green;
                break;
        }
    }
    public void SetMenuColors()
    {
        switch (theme)
        {
            case "Purple":
                menuBG.GetComponent<SpriteRenderer>().color = purple;
                break;

            case "Blue":
                menuBG.GetComponent<SpriteRenderer>().color = blue;
                break;

            case "Red":
                menuBG.GetComponent<SpriteRenderer>().color = red;
                break;

            case "Green":
                menuBG.GetComponent<SpriteRenderer>().color = green;
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
}

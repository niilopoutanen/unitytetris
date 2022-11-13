using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsLogic : MonoBehaviour
{
    public Slider GuideSwitch;
    public Slider PerformanceSwitch;
    public Slider AudioSwitch;
    public Slider MouseControlsSwitch;
    public MenuButtons menuButtons;
    void Start()
    {
        GuideSwitch.value = PlayerPrefs.GetInt("GuideVisible", 1);
        PerformanceSwitch.value = PlayerPrefs.GetInt("PerformanceOn");
        AudioSwitch.value = PlayerPrefs.GetInt("AudioOn", 1);
        MouseControlsSwitch.value = PlayerPrefs.GetInt("MouseControls");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menuButtons.ToMainMenu(false);
        }
    }
    public void PerformanceValueChanged(float value)
    {
        if (value == 0)
        {
            PlayerPrefs.SetInt("PerformanceOn", 0);
            PerformanceSwitch.gameObject.transform.Find("Active").GetComponent<Image>().enabled = false;
            QualitySettings.SetQualityLevel(0);
        }
        else
        {
            PlayerPrefs.SetInt("PerformanceOn", 1);
            PerformanceSwitch.gameObject.transform.Find("Active").GetComponent<Image>().enabled = true;
            QualitySettings.SetQualityLevel(1);
        }
    }
    public void AudioValueChanged(float value)
    {
        if (value == 0)
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("AudioOn", 0);
            AudioSwitch.gameObject.transform.Find("Active").GetComponent<Image>().enabled = false;
        }
        else
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("AudioOn", 1);
            AudioSwitch.gameObject.transform.Find("Active").GetComponent<Image>().enabled = true;
        }
    }
    public void GuideValueChanged(float value)
    {
        if (value == 0)
        {
            PlayerPrefs.SetInt("GuideVisible", 0);
            GuideSwitch.gameObject.transform.Find("Active").GetComponent<Image>().enabled = false;

        }
        else
        {
            PlayerPrefs.SetInt("GuideVisible", 1);
            GuideSwitch.gameObject.transform.Find("Active").GetComponent<Image>().enabled = true;

        }
    }
    public void ResetAchievementsClick()
    {
        Player player = new();
        player.SavePlayer();
    }

    public void MouseControlsValueChanged(float value)
    {
        if (value == 0)
        {
            PlayerPrefs.SetInt("MouseControls", 0);
            MouseControlsSwitch.gameObject.transform.Find("Active").GetComponent<Image>().enabled = false;
        }
        else
        {
            PlayerPrefs.SetInt("MouseControls", 1);
            MouseControlsSwitch.gameObject.transform.Find("Active").GetComponent<Image>().enabled = true;
        }
    }
}

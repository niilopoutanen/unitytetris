using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsLogic : MonoBehaviour
{
    public Slider GuideSwitch;
    public Slider PerformanceSwitch;
    public Slider AudioSwitch;
    public MenuButtons menuButtons;
    void Start()
    {
        GuideSwitch.value = PlayerPrefs.GetInt("GuideVisible", 1);
        PerformanceSwitch.value = PlayerPrefs.GetInt("PerformanceOn");
        AudioSwitch.value = PlayerPrefs.GetInt("AudioOn", 1);
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
        }
        else
        {
            PlayerPrefs.SetInt("PerformanceOn", 1);
            PerformanceSwitch.gameObject.transform.Find("Active").GetComponent<Image>().enabled = true;
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
}

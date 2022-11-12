using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SplashScreen : MonoBehaviour
{
    public MenuButtons menuButtons;
    public VideoPlayer splashVideoPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        splashVideoPlayer.loopPointReached += EndReached;
        int performanceOn = PlayerPrefs.GetInt("PerformanceOn");
        int audioOn = PlayerPrefs.GetInt("AudioOn");
        if (performanceOn == 1)
        {
            QualitySettings.SetQualityLevel(0);
        }
        else if (performanceOn == 0)
        {
            QualitySettings.SetQualityLevel(1);
        }
        Debug.Log(QualitySettings.GetQualityLevel());

        if (audioOn == 0)
        {
            AudioListener.volume = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        menuButtons.ToMainMenu(false);
    }
}

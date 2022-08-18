using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIClass : MonoBehaviour
{

    public Text Score;

    public void ChangeText()
    {
        GameLogic.ScoreValue
        Score.text = "testi";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
